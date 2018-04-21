using Game.Scripts.Unit;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class HealthDisplay : MonoBehaviour
    {
        private Health _playerHealth;
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void Start()
        {
            _playerHealth = GameObject.FindGameObjectWithTag(SRTags.Player).GetComponent<Health>();
            _playerHealth.CurrentHealth.Subscribe(x => _text.text = x.ToString());
        }
    }
}