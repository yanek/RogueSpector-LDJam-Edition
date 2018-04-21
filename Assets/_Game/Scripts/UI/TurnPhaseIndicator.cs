using Game.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class TurnPhaseIndicator : MonoBehaviour
    {
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void Update()
        {
            TurnManager.Phase phase = TurnManager.Instance.CurrentPhase.Value;
            switch (phase)
            {
                case TurnManager.Phase.PlayerMove:
                    _text.text = "Move!";
                    break;
                default:
                    _text.text = "Stand by...";
                    break;
            }
        }
    }
}