// Created:   2018/04/21
// Filename:    ScoreManager.cs
// Copyright (c) Noé Ksiazek.
//
// Made for Unity 2017.1.1f1

using UniRx;

namespace Game.Scripts.Managers
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        public IntReactiveProperty Score { get; set; }

        private void Awake()
        {
            Score = new IntReactiveProperty { Value = 0 };
        }
    }
}