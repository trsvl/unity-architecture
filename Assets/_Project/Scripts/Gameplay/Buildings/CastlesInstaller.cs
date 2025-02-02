using _Project.Scripts.Gameplay.Troops;
using _Project.Scripts.GameSystemLogic;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Buildings
{
    public class BuildingsInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private Castle castlePrefab;
        [SerializeField] private Transform leftCastleSpawnPoint;
        [SerializeField] private Transform rightCastleSpawnPoint;


        public void Register(Container container)
        {
            var playerCastle = Instantiate(castlePrefab, leftCastleSpawnPoint);
            var enemyCastle = Instantiate(castlePrefab, rightCastleSpawnPoint);

            var castleEvents = container.GetService<CastleEvents>();
            var gameplayStateObserver = container.GetService<GameplayStateObserver>();
            
            playerCastle.transform.position = leftCastleSpawnPoint.position;
            enemyCastle.transform.position = rightCastleSpawnPoint.position;

            playerCastle.Init(5f, Team.Player, castleEvents, gameplayStateObserver);
            enemyCastle.Init(5f, Team.Enemy, castleEvents, gameplayStateObserver);
        }
    }
}