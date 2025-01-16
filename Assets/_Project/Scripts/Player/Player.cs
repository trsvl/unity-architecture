using UnityEngine;

namespace _Project.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;


        public void Move(Vector3 direction)
        {
            transform.position += direction * (Time.deltaTime * _speed);
        }
    }
}