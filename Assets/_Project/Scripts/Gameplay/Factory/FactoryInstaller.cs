using _Project.Scripts.Gameplay.Troops;
using Unity.VisualScripting;
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
            var obj = Instantiate(Resources.Load("Gameplay/Factory"));
            _factory = obj.GetComponent<Factory>();
            _factory?.Init(troopSpawnPosition);
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