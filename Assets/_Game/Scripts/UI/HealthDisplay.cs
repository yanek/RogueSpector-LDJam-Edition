using Game.Scripts.Unit;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class HealthDisplay : MonoBehaviour
    {
        [CanBeNull]
        private Health _playerHealth;

        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player == null)
            {
                gameObject.SetActive(false);
            }
            else
            {
                _playerHealth = player.GetComponent<Health>();
                _playerHealth.CurrentHealth.Subscribe(x => _text.text = x.ToString());
            }
        }
    }
}