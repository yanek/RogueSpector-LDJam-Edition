using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Unit;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class Spawner : Singleton<Spawner>
    {
        private int _lastRepairKitSpawnTurn;

        [SerializeField]
        private uint _maxUnits = 20;

        [SerializeField]
        private List<GameObject> _obstacles;

        [SerializeField]
        private GameObject _repairKit;

        [SerializeField]
        private List<GameObject> _ships;

        [SerializeField]
        private int _spawningRow = 12;

        private int _unitCount;

        private GameObject SpawnAny(GameObject obj)
        {
            Instantiate(obj);

            Vector2 pos = new Vector2(Random.Range(0, 8), _spawningRow);
            obj.transform.position = pos;
            return obj;
        }

        private void SpawnObstacle()
        {
            SpawnAny(_obstacles[Random.Range(0, _obstacles.Count)]);
        }

        private void SpawnRepairKit()
        {
            int turn = TurnManager.Instance.TurnCount.Value;
            if (turn < _lastRepairKitSpawnTurn + 10)
                return;

            IEnumerable<Vector3> positions = FindObjectsOfType<Rigidbody2D>().Select(x => x.transform.position);
            GameObject obj = SpawnAny(_repairKit);

            if (positions.Contains(obj.transform.position))
            {
                obj.GetComponent<Rigidbody2D>().simulated = false;
                obj.transform.localScale = Vector3.zero;
                TurnManager.Instance.Disposables.Add(obj);
                SpawnRepairKit();
            }
            else
            {
                _lastRepairKitSpawnTurn = turn;
            }
        }

        private void SpawnShip()
        {
            SpawnAny(_ships[Random.Range(0, _ships.Count)]);
        }

        private void Start()
        {
            TurnManager.Instance.TurnCount.Where(x => GameManager.Instance.CurrentState == GameManager.State.Standard)
                       .Subscribe(x =>
                       {
                           _unitCount = GameObject.FindGameObjectsWithTag("Enemy").Count(y => y.GetComponent<Shooter>() != null) +
                                        GameObject.FindGameObjectsWithTag("Friend").Length;

                           SpawnObstacle();
                           SpawnRepairKit();
                           if (_unitCount < _maxUnits)
                               SpawnShip();
                       });
        }
    }
}