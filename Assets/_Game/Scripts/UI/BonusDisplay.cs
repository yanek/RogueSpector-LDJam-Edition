using Game.Scripts.Unit;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class BonusDisplay : MonoBehaviour
    {
        [SerializeField]
        private Text _atk;

        private Bonuses _bonuses;

        [SerializeField]
        private Text _def;

        private void Awake()
        {
            _bonuses = GameObject.FindGameObjectWithTag("Player").GetComponent<Bonuses>();
        }

        private void Start()
        {
            _bonuses.ObserveEveryValueChanged(x => Mathf.RoundToInt(x.transform.position.y))
                    .Subscribe(x =>
                    {
                        if (_bonuses.AttackActive && !_bonuses.DefenseActive)
                        {
                            _atk.color = Color.cyan;
                            _def.color = Color.yellow;
                        }
                        else if (_bonuses.DefenseActive && !_bonuses.AttackActive)
                        {
                            _def.color = Color.cyan;
                            _atk.color = Color.yellow;
                        }
                        else
                        {
                            _atk.color = Color.gray;
                            _def.color = Color.gray;
                        }
                    });
        }
    }
}