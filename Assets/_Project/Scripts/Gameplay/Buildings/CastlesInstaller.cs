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
            var castleEvents = container.GetService<CastleEvents>();
            var gameplayStateObserver = container.GetService<GameplayStateObserver>();

            SpawnCastle(Team.Player, castleEvents, gameplayStateObserver, leftCastleSpawnPoint);
            SpawnCastle(Team.Enemy, castleEvents, gameplayStateObserver, rightCastleSpawnPoint);
        }

        private void SpawnCastle(Team team, CastleEvents castleEvents, GameplayStateObserver gameplayStateObserver,
            Transform castleSpawnPoint)
        {
            var castle = Instantiate(castlePrefab);
            var objCollider = castle.GetComponent<Collider2D>();
            castle.transform.position = castleSpawnPoint.position;
            castle.Init(objCollider, 5f, team, castleEvents, gameplayStateObserver);
        }
    }
}