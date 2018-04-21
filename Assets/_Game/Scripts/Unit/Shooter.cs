using Game.Scripts.Managers;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Unit
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField]
        private int _frequency;

        private int _lastShotTurn;

        private void Shoot(int turn)
        {
            if (turn >= _lastShotTurn + _frequency)
            {
                TurnManager.Instance.Shots.Add(gameObject);
                _lastShotTurn = turn;
            }
        }

        private void Start()
        {
            int turn = TurnManager.Instance.TurnCount.Value;
            _lastShotTurn = Random.Range(turn, _frequency + turn);

            TurnManager.Instance.TurnCount.Subscribe(Shoot).AddTo(this);
        }
    }
}