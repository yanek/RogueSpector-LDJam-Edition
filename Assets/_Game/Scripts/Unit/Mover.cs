using DG.Tweening;
using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.Unit
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Health))]
    public class Mover : MonoBehaviour
    {
        public void Move(Vector2 direction)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 destination = new Vector2(Mathf.Round(rb.position.x), Mathf.Round(rb.position.y)) + direction;

            if (gameObject.CompareTag("Player") && GameManager.Instance.CurrentState == GameManager.State.Standard)
            {
                rb.DOMove(destination, 0.1f).OnComplete(() => { TurnManager.Instance.CurrentPhase.Value = TurnManager.Phase.Shot; });
                TurnManager.Instance.TurnCount.Value++;
            }
            else
            {
                if (!TurnManager.Instance.EnemyMoves.ContainsKey(rb)) TurnManager.Instance.EnemyMoves.Add(rb, destination);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Bullet") || !gameObject.CompareTag("Player")) return;
            Debug.Log(name + " collided with " + other.gameObject.name);

            Health health = GetComponent<Health>();
            if (health != null) health.TakeDamage(999);
        }
    }
}