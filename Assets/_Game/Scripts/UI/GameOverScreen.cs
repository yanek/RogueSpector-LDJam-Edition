using DG.Tweening;
using Game.Scripts.Managers;
using Unity.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    private Text _actionText;

    private void Start()
    {
        GameManager.Instance.CurrentState = GameManager.State.GameOver;
        DOTween.Sequence().Append(_actionText.DOFade(0.5f, 0.5f)).Append(_actionText.DOFade(1f, 0.5f)).SetLoops(-1);

        TurnManager.Instance.Disposables.Clear();
        TurnManager.Instance.Shots.Clear();
        TurnManager.Instance.EnemyMoves.Clear();

        GameObject.FindGameObjectsWithTag("Grid").Destroy();
        GameObject.FindGameObjectsWithTag("Bullet").Destroy();
        GameObject.FindGameObjectsWithTag("Friend").Destroy();
        GameObject.FindGameObjectsWithTag("Enemy").Destroy();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            GameManager.Instance.StartOver();
            gameObject.Destroy();
        }
    }
}