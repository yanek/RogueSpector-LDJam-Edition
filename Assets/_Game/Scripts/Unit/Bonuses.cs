// Created:   2018/04/22
// Filename:    Bonuses.cs
// Copyright (c) Noé Ksiazek.
//
// Made for Unity 2017.1.1f1

using UniRx;
using UnityEngine;

namespace Game.Scripts.Unit
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Shooter))]
    public class Bonuses : MonoBehaviour
    {
        private GameObject _fx;
        private Health _health;
        private Shooter _shooter;
        public bool AttackActive { get; set; }
        public bool DefenseActive { get; set; }

        private void Awake()
        {
            _health = GetComponent<Health>();
            _shooter = GetComponent<Shooter>();
        }

        private void CreateFx(GameObject prefab)
        {
            _fx = Instantiate(prefab, transform);
        }

        private void Start()
        {
            transform.ObserveEveryValueChanged(x => Mathf.RoundToInt(x.position.y))
                     .Subscribe(x =>
                     {
                         if (_fx != null) Destroy(_fx);
                         switch (x)
                         {
                             case 0:
                                 _shooter.ShotsPerTurn = 1;
                                 _health.Defense = 30;
                                 AttackActive = false;
                                 DefenseActive = true;
                                 CreateFx(SRResources.Prefabs.Dynamic.Shield);
                                 break;
                             case 1:
                                 _shooter.ShotsPerTurn = 3;
                                 _health.Defense = 0;
                                 AttackActive = false;
                                 DefenseActive = false;
                                 break;
                             case 2:
                                 _shooter.ShotsPerTurn = 5;
                                 _health.Defense = -30;
                                 AttackActive = true;
                                 DefenseActive = false;
                                 CreateFx(SRResources.Prefabs.Dynamic.BulletCharge02);
                                 break;
                             default:
                                 Debug.LogWarning("Illegal player position.");
                                 return;
                         }
                     });
        }
    }
}