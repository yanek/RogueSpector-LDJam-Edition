using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Game.Scripts.Dynamic;
using Game.Scripts.Managers;
using UniRx;
using Unity.Linq;
using UnityEngine;

namespace Game.Scripts.Unit
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private int _maxHealth = 100;

        public IntReactiveProperty CurrentHealth { get; set; }

        public Subject<GameObject> OnDeath { get; set; }

        public void HandleDeath(GameObject obj)
        {
            IEnumerable<Bullet> bullets = GameObject.FindGameObjectsWithTag(SRTags.Bullet)
                                                    .Select(x => x.GetComponent<Bullet>())
                                                    .Where(x => x.Emitter == obj);
            foreach (Bullet bullet in bullets) { TurnManager.Instance.Disposables.Add(bullet.gameObject); }

            if (obj.CompareTag(SRTags.Player))
            {
                SRResources.Prefabs.UI.GameOverScreen.Instantiate(FindObjectOfType<Canvas>().transform);
                GameObject explo = SRResources.Prefabs.Dynamic.Explo01.Instantiate(transform.position);
                explo.transform.DOPunchScale(Vector3.one * 40, 3f, 2, 5f).OnComplete(() => explo.Destroy());
                obj.Destroy();
            }
            else { TurnManager.Instance.Disposables.Add(obj); }
        }

        public int Heal(uint amount)
        {
            CurrentHealth.Value += (int)amount;
            return CurrentHealth.Value;
        }

        public int TakeDamage(uint amount)
        {
            CurrentHealth.Value -= (int)amount;
            Vector3 pos = transform.position;
            transform.DOShakePosition(0.2f, 0.25f, 20).OnComplete(() => { transform.position = pos; });
            return CurrentHealth.Value;
        }

        private void Awake()
        {
            CurrentHealth = new IntReactiveProperty { Value = _maxHealth };
            OnDeath = new Subject<GameObject>();
        }

        private void Start()
        {
            CurrentHealth.Subscribe(x =>
                         {
                             if (x > _maxHealth) { CurrentHealth.Value = _maxHealth; }

                             if (CurrentHealth.Value <= 0) { OnDeath.OnNext(gameObject); }
                         })
                         .AddTo(this);

            OnDeath.Subscribe(HandleDeath);
        }
    }
}