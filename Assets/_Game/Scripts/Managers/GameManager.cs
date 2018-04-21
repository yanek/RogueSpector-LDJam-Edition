using Unity.Linq;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public enum State
        {
            Standard,
            GameOver
        }

        public State CurrentState { get; set; }

        public void StartOver()
        {
            GameObject player = SRResources.Prefabs.Units.Player.Instantiate();
            CurrentState = State.Standard;

            TurnManager.Instance.CurrentPhase.Value = TurnManager.Phase.PlayerMove;
            player.transform.position = new Vector2(4, 0);

            Transform canvas = FindObjectOfType<Canvas>().transform;
            SRResources.Prefabs.UI.TurnPhaseIndicator.Instantiate(canvas);
            SRResources.Prefabs.UI.BottomBar.Instantiate(canvas);

        }

        private void Awake()
        {
            CurrentState = State.Standard;
        }
    }
}