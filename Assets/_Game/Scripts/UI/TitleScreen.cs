// Created:   2018/04/22
// Filename:    TitleScreen.cs
// Copyright (c) Noé Ksiazek.
//
// Made for Unity 2017.1.1f1

using DG.Tweening;
using Game.Scripts.Managers;
using Unity.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class TitleScreen : MonoBehaviour
    {
        [SerializeField]
        private Text _actionText;

        private void Start()
        {
            GameManager.Instance.CurrentState = GameManager.State.Title;
            DOTween.Sequence().Append(_actionText.DOFade(0.5f, 0.5f)).Append(_actionText.DOFade(1f, 0.5f)).SetLoops(-1);
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
}