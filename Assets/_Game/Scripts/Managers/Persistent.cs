using UnityEngine;

namespace Game.Scripts.Managers
{
    public class Persistent : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}