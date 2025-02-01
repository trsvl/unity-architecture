using System.Collections.Generic;
using _Project.Scripts.Gameplay.Troops;
using _Project.Scripts.Utils;
using UnityEngine;
using UnityEngine.Pool;

namespace _Project.Scripts.Gameplay
{
    public class Factory : Singleton<Factory>
    {
        private readonly Dictionary<PoolType, IObjectPool<PoolBase>> _pools = new();
        private TroopSpawnPosition _troopSpawnPosition;
        private DeathAnimationConfig _deathAnimationConfig;

        public void Init(TroopSpawnPosition troopSpawnPosition, DeathAnimationConfig deathAnimationConfig)
        {
            _troopSpawnPosition = troopSpawnPosition;
            _deathAnimationConfig = deathAnimationConfig;
        }

        public void Spawn(BaseConfig config)
        {
            GetPool(config).Get();
        }

        public void Spawn(BaseConfig config, Team team)
        {
            PoolBase obj = GetPool(config).Get();
            if (obj is TroopBase troop)
            {
                troop.Spawn(team);
                Vector2 troopPosition = _troopSpawnPosition.SetPosition(team);
                troop.transform.position = troopPosition;
            }
        }

        public void SpawnDeathAnimation(TroopBase troop)
        {
            PoolBase deathAnimation = GetPool(_deathAnimationConfig).Get();
            deathAnimation.gameObject.transform.localScale = troop.transform.localScale;
            deathAnimation.transform.position = troop.transform.position;
        }

        public void ReturnToPool(PoolBase obj)
        {
            GetPool(obj.Config).Release(obj);
        }

        private IObjectPool<PoolBase> GetPool(BaseConfig config, Team team)
        {
            IObjectPool<PoolBase> pool;

            if (_pools.TryGetValue(config.PoolType, out pool)) return pool;

            Debug.Log("team " + team);

            pool = new ObjectPool<PoolBase>(
                config.OnCreate,
                obj => obj.gameObject.SetActive(true),
                config.OnRelease,
                config.OnDestroyObject,
                false,
                5,
                20
            );

            _pools.Add(config.PoolType, pool);
            return pool;
        }

        private IObjectPool<PoolBase> GetPool(BaseConfig config)
        {
            IObjectPool<PoolBase> pool;

            if (_pools.TryGetValue(config.PoolType, out pool)) return pool;

            pool = new ObjectPool<PoolBase>(
                config.OnCreate,
                config.OnSpawn,
                config.OnRelease,
                config.OnDestroyObject,
                false,
                5,
                20
            );

            _pools.Add(config.PoolType, pool);
            return pool;
        }
    }
}