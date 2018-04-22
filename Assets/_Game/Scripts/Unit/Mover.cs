using DG.Tweening;
using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.Unit
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Health))]
    public class Mover : MonoBehaviour
    {
        public const int MaxColumn = 8;
        public const int MinColumn = 0;
        private Vector2 _previousPos;
        private Rigidbody2D _rb;

        public void Move(Vector2 direction)
        {
            Vector2 destination = new Vector2(Mathf.Round(_rb.position.x), Mathf.Round(_rb.position.y)) + direction;
            _previousPos = transform.position;

            if (gameObject.CompareTag("Player") && GameManager.Instance.CurrentState == GameManager.State.Standard)
            {
                _rb.DOMove(destination, 0.1f).OnComplete(() => { TurnManager.Instance.CurrentPhase.Value = TurnManager.Phase.Shot; });
                TurnManager.Instance.TurnCount.Value++;
            }
            else
            {
                if (!TurnManager.Instance.EnemyMoves.ContainsKey(_rb))
                    TurnManager.Instance.EnemyMoves.Add(_rb, destination);
            }
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Bullet"))
                return;

            if (CompareTag("Player") || CompareTag("Enemy") && other.gameObject.CompareTag("Friend"))
            {
                Debug.Log(name + " collided with " + other.gameObject.name);
                Health health = GetComponent<Health>();
                if (health != null)
                    health.TakeDamage(999);
            }
        }
    }
}