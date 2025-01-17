using UnityEngine;
using System.Threading.Tasks;

namespace _Project.Scripts
{
    public class PlayerInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private Player player;


        public void Register(Container container)
        {
            PlayerInput playerInput = new PlayerInput();
            container.Bind(playerInput);

            PlayerController playerController = new PlayerController(playerInput, player);
            container.Bind(playerController);
        }
    }
}