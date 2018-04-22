using DG.Tweening;
using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.Unit
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RepairKit : MonoBehaviour
    {
        private const int HealValue = 100;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = Camera.main.GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Health>().Heal(HealValue);
                _audioSource.PlayOneShot(Resources.Load<AudioClip>("SFX/S_Powerup"));
                gameObject.transform.DOScale(0, 0.5f);
                TurnManager.Instance.Disposables.Add(gameObject);
            }
        }
    }
}