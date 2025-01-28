using _Project.Scripts.Gameplay.ScriptableObjects;
using UnityEngine;

namespace _Project.Scripts.Gameplay
{
    public class FactoryInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private Collider2D _playerSpawnArea;
        [SerializeField] private Collider2D _enemySpawnArea;
        [SerializeField] private AttackingTroopConfig attackingTroopConfig;

        private Factory _factory;

        public void Register(Container container)
        {
            var troopSpawnPosition = new TroopSpawnPosition(_playerSpawnArea, _enemySpawnArea);
            _factory = new Factory(troopSpawnPosition);

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