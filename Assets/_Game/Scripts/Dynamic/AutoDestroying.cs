using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.Dynamic
{
    public class AutoDestroying : MonoBehaviour
    {
        [SerializeField]
        private int _maxRow = 15;

        [SerializeField]
        private int _minRow = -5;

        private void Update()
        {
            if (transform.position.y > _maxRow) { TurnManager.Instance.Disposables.Add(gameObject); }

            if (transform.position.y < _minRow) { TurnManager.Instance.Disposables.Add(gameObject); }
        }
    }
}