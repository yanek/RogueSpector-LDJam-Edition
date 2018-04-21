﻿using UnityEngine;

namespace Game.Scripts
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject { name = typeof(T).Name };
                        _instance = obj.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }
    }
}