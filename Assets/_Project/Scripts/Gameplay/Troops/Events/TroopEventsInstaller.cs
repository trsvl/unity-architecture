using _Project.Scripts.GameSystemLogic;
using Unity.VisualScripting;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class TroopEventsInstaller : MonoBehaviour, IInstaller
    {
        private TroopEvents _troopEvents;
        private ChangeTroopColor _changeTroopColor;

        public void Register(Container container)
        {
            _troopEvents = Instantiate(Resources.Load("Effects/TroopEvents")).GetComponent<TroopEvents>();

            _changeTroopColor = new ChangeTroopColor();

            OnEnable();
        }

        private void OnEnable()
        {
            if (_troopEvents == null || !_troopEvents.IsNull) return;

            _troopEvents.OnTakeDamage += _changeTroopColor.Do;
            _troopEvents.OnDeath += Factory.Instance.ReturnToPool;
            _troopEvents.OnDeath += Factory.Instance.SpawnDeathAnimation;
        }

        private void OnDisable()
        {
            if (_troopEvents == null || _troopEvents.IsNull) return;

            _troopEvents.OnTakeDamage -= _changeTroopColor.Do;
            _troopEvents.OnDeath -= Factory.Instance.ReturnToPool;
            _troopEvents.OnDeath -= Factory.Instance.SpawnDeathAnimation;
        }
    }
}