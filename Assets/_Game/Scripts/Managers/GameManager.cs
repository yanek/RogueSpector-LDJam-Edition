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
            GameObject player = Instantiate(ManagedPrefabs.Bank[PrefabID.Player]);
            CurrentState = State.Standard;

            ScoreManager.Instance.Score.Value = 0;
            TurnManager.Instance.TurnCount.Value = 1;
            TurnManager.Instance.CurrentPhase.Value = TurnManager.Phase.PlayerMove;
            player.transform.position = new Vector2(4, 0);

            Transform canvas = FindObjectOfType<Canvas>().transform;
            Instantiate(ManagedPrefabs.Bank[PrefabID.UI_TurnPhaseIndicator], canvas);
            Instantiate(ManagedPrefabs.Bank[PrefabID.UI_BottomBar], canvas);
            Instantiate(ManagedPrefabs.Bank[PrefabID.GridSet]);
        }

        private void Awake()
        {
            CurrentState = State.Standard;
        }
    }
}