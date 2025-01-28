using _Project.Scripts.Gameplay.ScriptableObjects;
using UnityEngine;

namespace _Project.Scripts.Gameplay
{
    public class FactoryInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private AttackingTroopConfig attackingTroopConfig;
        private Factory _factory;

        public void Register(Container container)
        {
            _factory = new Factory();
            container.Bind(_factory, isSingleton: true);

            CreatePlayerKnight();
            CreateEnemyKnight();
        }

        [ContextMenu("Create Player knight")]
        public void CreatePlayerKnight()
        {
            _factory.Spawn(attackingTroopConfig, Team.Player);
        }

        [ContextMenu("Create Enemy knight")]
        public void CreateEnemyKnight()
        {
            _factory.Spawn(attackingTroopConfig, Team.Enemy);
        }
    }
}