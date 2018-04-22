using Game.Scripts.Managers;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Unit
{
    public class Shooter : MonoBehaviour
    {
        private BulletCharge _bulletCharge;

        [SerializeField]
        private int _frequency;

        private int _lastShotTurn;

        [SerializeField]
        private int _shotsPerTurn;

        public int ShotsPerTurn
        {
            get { return _shotsPerTurn; }
            set { _shotsPerTurn = value; }
        }

        private void Awake()
        {
            _bulletCharge = GetComponentInChildren<BulletCharge>(true);
        }

        private void ChargeFx(int turn)
        {
            if (turn >= _lastShotTurn + _frequency - 1 && !_bulletCharge.isActiveAndEnabled) _bulletCharge.gameObject.SetActive(true);
        }

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
            TurnManager.Instance.TurnCount.Where(x => _bulletCharge != null).Subscribe(ChargeFx).AddTo(this);
        }
    }
}