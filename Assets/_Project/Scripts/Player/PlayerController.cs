using UnityEngine;

namespace _Project.Scripts
{
    public class PlayerController : IStartGame, IPauseGame, IResumeGame, IFinishGame
    {
        private readonly PlayerInput _playerInput;
        private readonly Player _player;


        public PlayerController(PlayerInput playerInput, Player player)
        {
            _playerInput = playerInput;
            _player = player;
        }

        public void StartGame()
        {
            _playerInput.OnMove += Move;
        }

        public void ResumeGame()
        {
            _playerInput.OnMove += Move;
        }

        public void PauseGame()
        {
            _playerInput.OnMove -= Move;
        }

        public void FinishGame()
        {
            _playerInput.OnMove -= Move;
        }

        private void Move(Vector3 direction)
        {
            _player.Move(direction);
        }
    }
}