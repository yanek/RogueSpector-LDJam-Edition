// Created:   2018/04/21
// Filename:    GridManager.cs
// Copyright (c) Noé Ksiazek.
//
// Made for Unity 2017.1.1f1

using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class GridManager : Singleton<GridManager>
    {
        private Dictionary<GameObject, Vector2> _cells;

        public void ChangeReservedCell(GameObject obj, Vector2 destination)
        {
            if (_cells.ContainsKey(obj)) { _cells[obj] = destination; }
            else { _cells.Add(obj, destination); }
        }

        public bool IsFree(Vector2 cell)
        {
            if (_cells.ContainsValue(cell)) { return false; }

            return true;
        }

        public void RemoveObject(GameObject obj)
        {
            _cells.Remove(obj);
        }

        private void Awake()
        {
            _cells = new Dictionary<GameObject, Vector2>();
        }
    }
}