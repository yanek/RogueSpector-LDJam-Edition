using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Game.Scripts.Dynamic;
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
                StartCoroutine(shooter.CompareTag(SRTags.Player)
                                   ? Bullet.SpawnBullets(3, SRResources.Prefabs.Dynamic.Bullet02, shooter)
                                   : Bullet.SpawnBullets(5, SRResources.Prefabs.Dynamic.Bullet01, shooter));
            }

            yield return new WaitForSeconds(Bullet.BulletFlyTime / 2);

            Shots.Clear();
            CurrentPhase.Value = Phase.Resolution;
        }

        private IEnumerator Resolve()
        {
            GameObject box = new GameObject();
            foreach (GameObject disposable in Disposables)
            {
                if (disposable.CompareTag(SRTags.Enemy) || disposable.CompareTag(SRTags.Friend))
                {
                    GameObject explo = SRResources.Prefabs.Dynamic.Explo01.Instantiate(disposable.transform.position);
                    explo.transform.DOPunchScale(Vector3.one * 3, 1f, 2, 0f).OnComplete(() => explo.Destroy());
                }

                disposable.transform.SetParent(box.transform);
            }

            yield return null;

            Destroy(box);
            Disposables.Clear();
            CurrentPhase.Value = Phase.AiMove;
        }

        private void Start()
        {
            Instance.TurnCount.Subscribe(x => { ScoreManager.Instance.Score.Value += 50; });
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