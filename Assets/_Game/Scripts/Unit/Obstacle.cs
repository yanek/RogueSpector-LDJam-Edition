using UnityEngine;

namespace Game.Scripts.Unit
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Obstacle : MonoBehaviour
    {
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _rb.MoveRotation(Random.Range(0, 359));
        }
    }
}