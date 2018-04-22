using Game.Scripts.Managers;
using Unity.Linq;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.CurrentState = GameManager.State.GameOver;

        TurnManager.Instance.Disposables.Clear();
        TurnManager.Instance.Shots.Clear();
        TurnManager.Instance.EnemyMoves.Clear();

        GameObject.FindGameObjectsWithTag(SRTags.Bullet).Destroy();
        GameObject.FindGameObjectsWithTag(SRTags.Friend).Destroy();
        GameObject.FindGameObjectsWithTag(SRTags.Enemy).Destroy();
    }

    private void Update()
    {
        if (Input.GetButtonDown(SRInput.Submit))
        {
            GameManager.Instance.StartOver();
            gameObject.Destroy();
        }
    }
}