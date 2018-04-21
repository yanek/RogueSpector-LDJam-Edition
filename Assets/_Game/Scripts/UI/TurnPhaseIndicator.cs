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
            _text.text = "Turn #" + TurnManager.Instance.TurnCount.Value + "\n";
            TurnManager.Phase phase = TurnManager.Instance.CurrentPhase.Value;
            switch (phase)
            {
                case TurnManager.Phase.PlayerMove:
                    _text.text += "Move!";
                    break;
                case TurnManager.Phase.AiMove:
                    _text.text += "AI Movements...";
                    break;
                case TurnManager.Phase.Resolution:
                    _text.text += "Turn resolution...";
                    break;
                case TurnManager.Phase.Shot:
                    _text.text += "Pew! Pew!";
                    break;
                default:
                    _text.text += "Stand by...";
                    break;
            }
        }
    }
}