using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private float speed;


        public void Move(Vector3 direction)
        {
            transform.position += direction * (Time.deltaTime * speed);
        }
    }
}