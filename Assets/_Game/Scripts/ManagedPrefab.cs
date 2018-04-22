// Created:   2018/04/22
// Filename:    ManagedPrefab.cs
// Copyright (c) Noé Ksiazek.
//
// Made for Unity 2017.1.1f1

using System.Collections.Generic;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace Game.Scripts
{
    public enum PrefabID
    {
        Player,
        Shield,
        Bullet01,
        Bullet02,
        BulletCharge01,
        BulletCharge02,
        Explo01,
        Impact,
        GridSet,
        UI_TurnPhaseIndicator,
        UI_BottomBar,
        UI_GameOver
    }

    public static class ManagedPrefabs
    {
        public static Dictionary<PrefabID, GameObject> Bank;

        static ManagedPrefabs()
        {
            Bank = new Dictionary<PrefabID, GameObject>
                   {
                       { PrefabID.Player, Resources.Load<GameObject>("Prefabs/Units/Player") },
                       { PrefabID.Shield, Resources.Load<GameObject>("Prefabs/Dynamic/Shield") },
                       { PrefabID.BulletCharge01, Resources.Load<GameObject>("Prefabs/Dynamic/BulletCharge01") },
                       { PrefabID.BulletCharge02, Resources.Load<GameObject>("Prefabs/Dynamic/BulletCharge02") },
                       { PrefabID.Bullet01, Resources.Load<GameObject>("Prefabs/Dynamic/Bullet01") },
                       { PrefabID.Bullet02, Resources.Load<GameObject>("Prefabs/Dynamic/Bullet02") },
                       { PrefabID.Explo01, Resources.Load<GameObject>("Prefabs/Dynamic/Explo01") },
                       { PrefabID.Impact, Resources.Load<GameObject>("Prefabs/Dynamic/Impact") },
                       { PrefabID.GridSet, Resources.Load<GameObject>("Prefabs/Environement/GridSet") },
                       { PrefabID.UI_GameOver, Resources.Load<GameObject>("Prefabs/UI/GameOverScreen") },
                       {
                           PrefabID.UI_TurnPhaseIndicator,
                           Resources.Load<GameObject>("Prefabs/UI/TurnPhaseIndicator")
                       },
                       { PrefabID.UI_BottomBar, Resources.Load<GameObject>("Prefabs/UI/BottomBar") }
                   };
        }
    }
}