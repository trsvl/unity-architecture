using UnityEngine;

namespace _Project.Scripts.Gameplay
{
    public class TroopSpawnPosition
    {
        private readonly Collider2D _playerSpawnArea;
        private readonly Collider2D _enemySpawnArea;


        public TroopSpawnPosition(Collider2D playerSpawnArea, Collider2D enemySpawnArea)
        {
            _playerSpawnArea = playerSpawnArea;
            _enemySpawnArea = enemySpawnArea;
        }

        public Vector2 SetPosition(Team team)
        {
            if (team == Team.Player)
            {
                return GetRandomSpawnPosition(_playerSpawnArea);
            }
            else if (team == Team.Enemy)
            {
                return GetRandomSpawnPosition(_enemySpawnArea);
            }

            return Vector2.zero;
        }

        private Vector2 GetRandomSpawnPosition(Collider2D spawnArea)
        {
            Bounds bounds = spawnArea.bounds;

            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);

            Vector2 randomPosition = new Vector2(randomX, randomY);
            return randomPosition;
        }
    }
}