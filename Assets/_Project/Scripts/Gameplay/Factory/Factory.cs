using System.Collections.Generic;
using _Project.Scripts.Gameplay.ScriptableObjects;
using UnityEngine.Pool;

namespace _Project.Scripts.Gameplay
{
    public class Factory
    {
        private readonly Dictionary<PoolType, IObjectPool<PoolBase>> _pools = new();


        public PoolBase Spawn(BaseConfig config)
        {
            return GetPool(config).Get();
        }

        public PoolBase Spawn(BaseConfig config, Team team)
        {
            return GetPool(config, team).Get();
        }

        public void ReturnToPool(PoolBase obj)
        {
            GetPool(obj.Config).Release(obj);
        }

        private IObjectPool<PoolBase> GetPool(BaseConfig config, Team team)
        {
            IObjectPool<PoolBase> pool;

            if (_pools.TryGetValue(config.PoolType, out pool)) return pool;

            pool = new ObjectPool<PoolBase>(
                config.OnCreate,
                obj => config.OnSpawn(obj, team),
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