using _Project.Scripts.GameSystemLogic;
using Unity.VisualScripting;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class TroopEffectsInstaller : MonoBehaviour, IInstaller
    {
        private TroopEffects _troopEffects;
        private ChangeTroopColor _changeTroopColor;

        public void Register(Container container)
        {
            _troopEffects = Instantiate(Resources.Load("Effects/TroopEffects")).GetComponent<TroopEffects>();

            _changeTroopColor = new ChangeTroopColor();

            OnEnable();
        }

        private void OnEnable()
        {
            if (_troopEffects == null) return;

            _troopEffects.OnTakeDamage += _changeTroopColor.Do;
            _troopEffects.OnDeath += Factory.Instance.ReturnToPool;
            _troopEffects.OnDeath += Factory.Instance.SpawnDeathAnimation;
        }

        private void OnDisable()
        {
            if (_troopEffects == null) return;

            _troopEffects.OnTakeDamage -= _changeTroopColor.Do;
            _troopEffects.OnDeath -= Factory.Instance.ReturnToPool;
            _troopEffects.OnDeath -= Factory.Instance.SpawnDeathAnimation;
        }
    }
}