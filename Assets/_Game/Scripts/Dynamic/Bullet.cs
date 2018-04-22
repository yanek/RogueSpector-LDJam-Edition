// Created:   2018/04/21
// Filename:    Bullet.cs
// Copyright (c) Noé Ksiazek.
//
// Made for Unity 2017.1.1f1

using System.Collections;
using DG.Tweening;
using Game.Scripts.Managers;
using Game.Scripts.Unit;
using UnityEngine;

namespace Game.Scripts.Dynamic
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        public const float BulletFlyTime = 2f;
        private AudioSource _audioSource;

        [SerializeField]
        private uint _damage;

        private Rigidbody2D _rb;

        public uint Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public Vector2 Direction { get; set; }

        public GameObject Emitter { get; set; }

        public static IEnumerator SpawnBullets(int number, GameObject prefab, GameObject shooter)
        {
            BulletCharge charge = shooter.GetComponentInChildren<BulletCharge>();
            if (charge != null) charge.gameObject.SetActive(false);

            for (int i = 0; i < number; i++)
            {
                Bullet bullet = Instantiate(prefab).GetComponent<Bullet>();
                bullet.transform.position = shooter.transform.position;
                bullet.Direction = !shooter.CompareTag("Player") ? Vector3.down : Vector3.up;
                bullet.Emitter = shooter;
                yield return new WaitForSeconds(0.08f);
            }
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _audioSource = Camera.main.GetComponent<AudioSource>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject != Emitter && !other.gameObject.CompareTag("Bullet"))
            {
                //if the shooter is not the player, ensure that it cannot hit his friends.
                if (Emitter == null) return;
                if (!Emitter.CompareTag("Player") && !other.gameObject.CompareTag("Player")) return;

                //apply damage
                Health health = other.gameObject.GetComponent<Health>();
                if (health != null) health.TakeDamage(_damage);
                _audioSource.PlayOneShot(Resources.Load<AudioClip>("SFX/S_Hit02"));

                //increment score if shooted by player
                if (Emitter.CompareTag("Player") && other.gameObject.CompareTag("Enemy") && other.gameObject.GetComponent<Shooter>() != null)
                    ScoreManager.Instance.Score.Value += 10;

                StartCoroutine(PlayImpact(transform.position));

                transform.localScale = Vector3.zero;
                _rb.simulated = false;
                TurnManager.Instance.Disposables.Add(gameObject);
            }
        }

        private IEnumerator PlayImpact(Vector3 position)
        {
            GameObject impact = Instantiate(ManagedPrefabs.Bank[PrefabID.Impact]);
            impact.transform.position = position;

            yield return null;
            TurnManager.Instance.Disposables.Add(impact);
        }

        private void Start()
        {
            _audioSource.PlayOneShot(Resources.Load<AudioClip>("SFX/S_Shoot01"));
            _rb.DOMove(_rb.position + Direction * 20, BulletFlyTime);
        }
    }
}