// Created:   2018/04/21
// Filename:    ScoreDisplay.cs
// Copyright (c) Noé Ksiazek.
//
// Made for Unity 2017.1.1f1

using Game.Scripts.Managers;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void Start()
        {
            ScoreManager.Instance.Score.Subscribe(x => { _text.text = x.ToString(); }).AddTo(this);
        }
    }
}