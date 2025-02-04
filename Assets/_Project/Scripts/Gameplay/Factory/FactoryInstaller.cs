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


        public void Register(Container container)
        {
            var troopSpawnPosition = new TroopSpawnPosition(_playerSpawnArea, _enemySpawnArea);
            var factory = Instantiate(Resources.Load<Factory>("Gameplay/Factory")).GetComponent<Factory>();
            factory.Init(troopSpawnPosition, deathAnimationConfig);
        }
    }
}