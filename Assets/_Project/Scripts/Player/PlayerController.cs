using _Project.Scripts.GameSystemLogic.Interfaces;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerController : MonoBehaviour, IStartGame, IFinishGame
    {
        private PlayerInput _playerInput;
        private PlayerManager _playerManager;


        public void Construct(PlayerInput playerInput, PlayerManager playerManager)
        {
            _playerInput = playerInput;
            _playerManager = playerManager;
        }

        public void StartGame()
        {
            _playerInput.OnMove += Move;
        }

        public void FinishGame()
        {
            _playerInput.OnMove -= Move;
        }

        private void Move(Vector3 direction)
        {
            _playerManager.Move(direction);
        }
    }
}