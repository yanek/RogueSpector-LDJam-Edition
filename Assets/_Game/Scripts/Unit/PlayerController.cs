using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.Unit
{
    [RequireComponent(typeof(Mover))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private int _maxCol = 8;

        [SerializeField]
        private int _maxRow = 2;

        [SerializeField]
        private int _minCol;

        [SerializeField]
        private int _minRow;

        private Mover _mover;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
        }

        private void HandleInputs()
        {
            if (Input.GetButtonDown(SRInput.Up) && transform.position.y < _maxRow) { _mover.Move(Vector2.up); }

            if (Input.GetButtonDown(SRInput.Down) && transform.position.y > _minRow) { _mover.Move(Vector2.down); }

            if (Input.GetButtonDown(SRInput.Left) && transform.position.x > _minCol) { _mover.Move(Vector2.left); }

            if (Input.GetButtonDown(SRInput.Right) && transform.position.x < _maxCol) { _mover.Move(Vector2.right); }
        }

        private void Update()
        {
            if (TurnManager.Instance.CurrentPhase.Value == TurnManager.Phase.PlayerMove) { HandleInputs(); }
        }
    }
}