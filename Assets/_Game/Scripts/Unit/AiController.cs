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

        private int _lastMoveTurn;

        [SerializeField]
        private int _maxCol = 8;

        [SerializeField]
        private int _minCol;

        private Mover _mover;

        [SerializeField]
        private int _moveRate = 1;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
        }

        private void Move()
        {
            Vector2 movement = Vector2.down;
            if (_canStrafe)
            {
                int roll = Random.Range(1, 100);
                if (roll < 50)
                {
                    if (roll <= 25 || transform.position.x >= _maxCol) { movement += Vector2.left; }
                    else if (roll > 25 || transform.position.x <= _minCol) { movement += Vector2.right; }
                }
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