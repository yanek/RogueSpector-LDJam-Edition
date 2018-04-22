using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Unit;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class AiSpawner : Singleton<AiSpawner>
    {
        [SerializeField]
        private uint _maxUnits = 20;

        [SerializeField]
        private List<GameObject> _obstacles;

        [SerializeField]
        private List<GameObject> _ships;

        [SerializeField]
        private int _spawningRow = 12;

        private int _unitCount;

        private void SpawnObstacle()
        {
            GameObject obj = Instantiate(_obstacles[Random.Range(0, _obstacles.Count)]);

            Vector2 pos = new Vector2(Random.Range(0, 8), _spawningRow);
            obj.transform.position = pos;
        }

        private void SpawnShip()
        {
            GameObject obj = Instantiate(_ships[Random.Range(0, _ships.Count)]);

            Vector2 pos = new Vector2(Random.Range(0, 8), _spawningRow);
            obj.transform.position = pos;
        }

        private void Start()
        {
            TurnManager.Instance.TurnCount.Where(x => GameManager.Instance.CurrentState == GameManager.State.Standard)
                       .Subscribe(x =>
                       {
                           _unitCount = GameObject.FindGameObjectsWithTag(SRTags.Enemy).Count(y => y.GetComponent<Shooter>() != null) +
                                        GameObject.FindGameObjectsWithTag(SRTags.Friend).Length;

                           SpawnObstacle();
                           if (_unitCount < _maxUnits) SpawnShip();
                       });
        }
    }
}