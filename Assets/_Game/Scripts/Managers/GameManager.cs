using UnityEngine;

namespace Game.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public const int MaxGridYPosition = 12;
        public const int MinGridYPosition = -1;

        public enum State
        {
            Standard,
            Title,
            GameOver
        }

        public State CurrentState { get; set; }

        public void StartOver()
        {
            GameObject player = SRResources.Prefabs.Units.Player.Instantiate();
            CurrentState = State.Standard;

            ScoreManager.Instance.Score.Value = 0;
            TurnManager.Instance.TurnCount.Value = 1;
            TurnManager.Instance.CurrentPhase.Value = TurnManager.Phase.PlayerMove;
            player.transform.position = new Vector2(4, 0);

            Transform canvas = FindObjectOfType<Canvas>().transform;
            SRResources.Prefabs.UI.TurnPhaseIndicator.Instantiate(canvas);
            SRResources.Prefabs.UI.BottomBar.Instantiate(canvas);
            SRResources.Prefabs.Environement.GridSet.Instantiate();
        }

        private void Awake()
        {
            CurrentState = State.Standard;
        }
    }
}