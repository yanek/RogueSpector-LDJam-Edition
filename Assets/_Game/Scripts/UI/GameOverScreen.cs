using Game.Scripts.Managers;
using Unity.Linq;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.CurrentState = GameManager.State.GameOver;

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