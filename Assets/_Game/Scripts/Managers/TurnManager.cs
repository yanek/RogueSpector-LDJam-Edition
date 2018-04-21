using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Game.Scripts.Dynamic;
using UniRx;
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
            Instance.TurnCount.Subscribe(x => { ScoreManager.Instance.Score.Value += 50; });
            Instance.CurrentPhase.Where(x => x == Phase.AiMove).Subscribe(x => MainThreadDispatcher.StartCoroutine(PlayEnemyMoves()));
            Instance.CurrentPhase.Where(x => x == Phase.Shot).Subscribe(x => MainThreadDispatcher.StartCoroutine(PlayShots()));
            Instance.CurrentPhase.Where(x => x == Phase.Resolution).Subscribe(x => MainThreadDispatcher.StartCoroutine(Resolve()));
        }

        private IEnumerator Resolve()
        {
            GameObject box = new GameObject();
            foreach (GameObject disposable in Disposables) { disposable.transform.SetParent(box.transform); }

            yield return null;

            Destroy(box);
            Disposables.Clear();
            CurrentPhase.Value = Phase.AiMove;
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
                GameObject bullet = SRResources.Prefabs.Dynamic.Bullet01.Instantiate();
                Bullet component = bullet.GetComponent<Bullet>();
                bullet.transform.position = shooter.transform.position;

                component.Direction = !shooter.CompareTag(SRTags.Player) ? Vector3.down : Vector3.up;
                component.Emitter = shooter;
            }

            yield return new WaitForSeconds(Bullet.BulletFlyTime);

            Shots.Clear();
            CurrentPhase.Value = Phase.Resolution;
        }
    }
}