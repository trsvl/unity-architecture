using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    [CreateAssetMenu(fileName = "BaseConfig", menuName = "SO/Troops", order = 0)]
    public class BaseConfig : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public PoolType PoolType { get; private set; }


        public virtual PoolBase OnCreate()
        {
            var obj = Instantiate(Prefab);
            obj.SetActive(false);
            var poolBase = obj.GetComponent<PoolBase>();
            poolBase.Config = this;
            return poolBase;
        }

        public virtual void OnSpawn(PoolBase obj)
        {
            obj.gameObject.SetActive(true);
        }

        public virtual void OnSpawn(PoolBase obj, Team team)
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