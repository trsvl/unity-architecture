using UnityEngine;

namespace _Project.Scripts.GameSystemLogic
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
            }
            else
            {
                Debug.LogError($"There is already an instance of {typeof(T).Name}");
                Destroy(gameObject);
            }
        }
    }
}