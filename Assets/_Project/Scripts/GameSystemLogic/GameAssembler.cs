using _Project.Scripts.Player;
using UnityEngine;
 
namespace _Project.Scripts.GameSystemLogic
{
    public class GameAssembler : MonoBehaviour
    {
        [SerializeField] private GameLocator gameLocator;
        [Space] [SerializeField] private PlayerController playerController;


        private void Start()
        {
            ConstructPlayerController();
        }

        private void ConstructPlayerController()
        {
            var keyboardInput = gameLocator.GetService<PlayerInput>();
            var player = gameLocator.GetService<PlayerManager>();
            playerController.Construct(keyboardInput, player);
        }
    }
}