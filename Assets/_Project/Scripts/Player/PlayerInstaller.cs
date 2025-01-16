using UnityEngine;
using System.Threading.Tasks;

namespace _Project.Scripts
{
    public class PlayerInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private Player player;


        public Task Register()
        {
            PlayerInput playerInput = new PlayerInput();
            PlayerController playerController = new PlayerController(playerInput, player);

            return Task.CompletedTask;
        }
    }
}