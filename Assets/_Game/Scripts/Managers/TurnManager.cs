using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Game.Scripts.Dynamic;
using Game.Scripts.Unit;
using UniRx;
using Unity.Linq;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class TurnManager : Singleton<TurnManager>
    {
        public enum Phase
        {
            AiMove,
            PlayerMove,
            Shot,
            Resolution
        }

        public ReactiveProperty<Phase> CurrentPhase { get; set; }
        public List<GameObject> Disposables { get; set; }
        public Dictionary<Rigidbody2D, Vector2> EnemyMoves { get; set; }
        public List<GameObject> Shots { get; set; }
        public IntReactiveProperty TurnCount { get; set; }

        private void Awake()
        {
            TurnCount = new IntReactiveProperty { Value = 1 };
            CurrentPhase = new ReactiveProperty<Phase> { Value = Phase.PlayerMove };
            EnemyMoves = new Dictionary<Rigidbody2D, Vector2>();
            Shots = new List<GameObject>();
            Disposables = new List<GameObject>();
        }

        private IEnumerator PlayEnemyMoves()
        {
            foreach (KeyValuePair<Rigidbody2D, Vector2> pair in EnemyMoves)
            {
                const float MoveDuration = 0.1f;
                pair.Key.DOMove(pair.Value, MoveDuration);
            }

            yield return null;

            EnemyMoves.Clear();
            CurrentPhase.Value = Phase.PlayerMove;
        }

        private IEnumerator PlayShots()
        {
            yield return new WaitForSeconds(0.2f);

            foreach (GameObject shooter in Shots)
            {
                GameObject prefab = shooter.CompareTag("Player") ? ManagedPrefabs.Bank[PrefabID.Bullet02] : ManagedPrefabs.Bank[PrefabID.Bullet01];
                StartCoroutine(Bullet.SpawnBullets(shooter.GetComponent<Shooter>().ShotsPerTurn, prefab, shooter));
            }

            yield return new WaitForSeconds(Bullet.BulletFlyTime / 2);

            Shots.Clear();
            CurrentPhase.Value = Phase.Resolution;
        }

        private IEnumerator Resolve()
        {
            GameObject box = new GameObject();
            AudioSource audioSource = Camera.main.GetComponent<AudioSource>();
            foreach (GameObject disposable in Disposables)
            {
                Health health = disposable.GetComponent<Health>();
                if ((disposable.CompareTag("Enemy") || disposable.CompareTag("Friend")) && health != null && health.CurrentHealth.Value <= 0)
                {
                    audioSource.PlayOneShot(Resources.Load<AudioClip>("SFX/S_Explo02"));
                    GameObject explo = Instantiate(ManagedPrefabs.Bank[PrefabID.Explo01]);
                    explo.transform.position = disposable.transform.position;
                    explo.transform.DOPunchScale(Vector3.one * 3, 1f, 2, 0f).OnComplete(() => explo.Destroy());
                }

                disposable.transform.SetParent(box.transform);
            }

            Destroy(box);
            Disposables.Clear();
            CurrentPhase.Value = Phase.AiMove;

            yield return null;
        }

        private void Start()
        {
            Instance.TurnCount.Where(x => x > 1).Subscribe(x => { ScoreManager.Instance.Score.Value += 50; });
            Instance.CurrentPhase.Where(x => GameManager.Instance.CurrentState == GameManager.State.Standard)
                    .Where(x => x == Phase.AiMove)
                    .Subscribe(x => StartCoroutine(PlayEnemyMoves()));
            Instance.CurrentPhase.Where(x => GameManager.Instance.CurrentState == GameManager.State.Standard)
                    .Where(x => x == Phase.Shot)
                    .Subscribe(x => StartCoroutine(PlayShots()));
            Instance.CurrentPhase.Where(x => GameManager.Instance.CurrentState == GameManager.State.Standard)
                    .Where(x => x == Phase.Resolution)
                    .Subscribe(x => StartCoroutine(Resolve()));
        }
    }
}