// Created:   2018/04/21
// Filename:    AIController.cs
// Copyright (c) Noé Ksiazek.
//
// Made for Unity 2017.1.1f1

using Game.Scripts.Managers;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Unit
{
    [RequireComponent(typeof(Mover))]
    public class AiController : MonoBehaviour
    {
        [SerializeField]
        private bool _canStrafe;

        private BulletCharge _charge;

        private int _lastMoveTurn;

        [SerializeField]
        private int _maxCol = 8;

        [SerializeField]
        private int _minCol;

        private Mover _mover;

        [SerializeField]
        private int _moveRate = 1;

        private GameObject _player;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
            _charge = GetComponentInChildren<BulletCharge>(true);
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Move()
        {
            Vector2 movement = Vector2.down;

            bool distanceCheck = _player == null || Vector2.Distance(_player.transform.position, transform.position) > 2;
            bool chargeCheck = _charge == null || !_charge.gameObject.activeSelf;

            if (_canStrafe && distanceCheck && chargeCheck)
            {
                int roll = Random.Range(1, 100);
                if (roll < 50)
                    if (roll <= 25 || transform.position.x >= _maxCol)
                        movement += Vector2.left;
                    else if (roll > 25 || transform.position.x <= _minCol) movement += Vector2.right;
            }

            _lastMoveTurn = TurnManager.Instance.TurnCount.Value;
            _mover.Move(movement);
        }

        private void Start()
        {
            TurnManager.Instance.TurnCount.Where(x => x >= _lastMoveTurn + _moveRate).Subscribe(x => Move()).AddTo(this);
        }
    }
}