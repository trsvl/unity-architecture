using _Project.Scripts.Gameplay.Troops;
using _Project.Scripts.Gameplay.Troops.Base;
using UnityEngine;

namespace _Project.Scripts.Gameplay
{
    public abstract class BaseConfig : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public PoolType PoolType { get; private set; }


        public virtual PoolBase OnCreate()
        {
            var obj = Instantiate(Prefab);
            var poolBase = obj.GetComponent<PoolBase>();
            poolBase.Config = this;
            obj.SetActive(false);
            return poolBase;
        }

        public virtual void OnSpawn(PoolBase obj)
        {
            obj.gameObject.SetActive(true);
        }

        public virtual void OnSpawn(TroopBase obj, Team team, int level)
        {
            obj.gameObject.SetActive(true);
        }

        public virtual void OnRelease(PoolBase obj)
        {
            obj.gameObject.SetActive(false);
        }

        public virtual void OnDestroyObject(PoolBase obj)
        {
            Destroy(obj.gameObject);
        }
    }
}