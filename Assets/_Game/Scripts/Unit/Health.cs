using DG.Tweening;
using Game.Scripts.Managers;
using UniRx;
using Unity.Linq;
using UnityEngine;

namespace Game.Scripts.Unit
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Health : MonoBehaviour
    {
        private AudioSource _audioSource;

        [SerializeField]
        private int _maxHealth = 100;

        private SpriteRenderer _sprite;

        public IntReactiveProperty CurrentHealth { get; set; }

        public int Defense { get; set; }

        public Subject<GameObject> OnDeath { get; set; }

        public void HandleDeath(GameObject obj)
        {
            if (obj.CompareTag(SRTags.Player))
            {
                SRResources.Prefabs.UI.GameOverScreen.Instantiate(FindObjectOfType<Canvas>().transform);
                _audioSource.PlayOneShot(SRResources.SFX.S_Explo01);
                GameObject explo = SRResources.Prefabs.Dynamic.Explo01.Instantiate(transform.position);
                explo.transform.DOPunchScale(Vector3.one * 40, 3f, 2, 5f).OnComplete(() => explo.Destroy());
                obj.Destroy();
            }
            else if (obj.CompareTag(SRTags.Friend))
            {
                GameObject.FindGameObjectWithTag(SRTags.Player).GetComponent<Health>().TakeDamage(100);
                TurnManager.Instance.Disposables.Add(obj);
            }
            else
            {
                TurnManager.Instance.Disposables.Add(obj);
            }
        }

        public int Heal(uint amount)
        {
            CurrentHealth.Value += (int)amount;
            return CurrentHealth.Value;
        }

        public int TakeDamage(uint amount)
        {
            CurrentHealth.Value -= (int)amount - Defense;
            DOTween.Sequence()
                   .Append(_sprite.DOColor(Color.red, 0))
                   .Append(_sprite.DOFade(0.5f, 0.1f))
                   .AppendInterval(0.1f)
                   .Append(_sprite.DOColor(Color.white, 0));
            return CurrentHealth.Value;
        }

        private void Awake()
        {
            CurrentHealth = new IntReactiveProperty { Value = _maxHealth };
            OnDeath = new Subject<GameObject>();
            _audioSource = Camera.main.GetComponent<AudioSource>();
            _sprite = GetComponent<SpriteRenderer>();
            Defense = 0;
        }

        private void Start()
        {
            CurrentHealth.Subscribe(x =>
                         {
                             if (gameObject.CompareTag(SRTags.Player)) _audioSource.PlayOneShot(SRResources.SFX.S_Hit01);

                             if (x > _maxHealth) CurrentHealth.Value = _maxHealth;

                             if (CurrentHealth.Value <= 0) OnDeath.OnNext(gameObject);
                         })
                         .AddTo(this);

            OnDeath.Subscribe(HandleDeath);
        }
    }
}