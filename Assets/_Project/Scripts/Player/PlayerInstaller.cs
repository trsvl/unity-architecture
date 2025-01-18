using UnityEngine;

namespace _Project.Scripts
{
    public class PlayerInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private Player playerPrefab;


        public void Register(Container container)
        {
            PlayerInput playerInput = new PlayerInput();
            container.Bind(playerInput, isSingleton: true);

            Player player = Instantiate(playerPrefab);
            container.Bind(player, isSingleton: true);

            PlayerController playerController = new PlayerController(playerInput, player);
            container.Bind(playerController, isSingleton: true);
        }
    }
}