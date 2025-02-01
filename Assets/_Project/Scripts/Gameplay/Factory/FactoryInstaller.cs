using _Project.Scripts.Gameplay.Troops;
using _Project.Scripts.GameSystemLogic;
using UnityEngine;

namespace _Project.Scripts.Gameplay
{
    public class FactoryInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private Collider2D _playerSpawnArea;
        [SerializeField] private Collider2D _enemySpawnArea;
        [SerializeField] private AttackingTroopConfig attackingTroopConfig;
        [SerializeField] private DeathAnimationConfig deathAnimationConfig;

        private Factory _factory;


        public void Register(Container container)
        {
            var troopSpawnPosition = new TroopSpawnPosition(_playerSpawnArea, _enemySpawnArea);
            _factory = Instantiate(Resources.Load<Factory>("Gameplay/Factory")).GetComponent<Factory>();
            _factory.Init(troopSpawnPosition, deathAnimationConfig);

            CreatePlayerKnight();
            CreatePlayerKnight();
            CreateEnemyKnight();
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