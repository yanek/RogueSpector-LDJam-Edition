// Created:   2018/04/21
// Filename:    Bullet.cs
// Copyright (c) Noé Ksiazek.
//
// Made for Unity 2017.1.1f1

using DG.Tweening;
using Game.Scripts.Managers;
using Game.Scripts.Unit;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Dynamic
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        public const float BulletFlyTime = 1f;

        [SerializeField]
        private uint _damage;

        private PlayerController _player;

        private Rigidbody2D _rb;

        public uint Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public Vector2 Direction { get; set; }

        public GameObject Emitter { get; set; }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _player = GameObject.FindGameObjectWithTag(SRTags.Player).GetComponent<PlayerController>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject != Emitter && !other.gameObject.CompareTag(SRTags.Bullet))
            {
                //if the shooter is not the player, ensure that it cannot hit his friends.
                if (!Emitter.CompareTag(SRTags.Player) && !other.gameObject.CompareTag(SRTags.Player)) { return; }

                //apply damage
                Health health = other.gameObject.GetComponent<Health>();
                if (health != null) { health.TakeDamage(_damage); }

                //increment score if shooted by player
                if (Emitter.CompareTag(SRTags.Player)) { ScoreManager.Instance.Score.Value += 100; }

                transform.localScale = Vector3.zero;
                _rb.simulated = false;
                TurnManager.Instance.Disposables.Add(gameObject);
            }
        }

        private void Start()
        {
            TurnManager.Instance.TurnCount.Subscribe(x => { _rb.DOMove(_rb.position + Direction * 20, BulletFlyTime); }).AddTo(this);
        }
    }
}