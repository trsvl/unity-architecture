using System;
using _Project.Scripts.GameSystemLogic.Interfaces;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerInput : MonoBehaviour, IStartGame, IFinishGame
    {
        public event Action<Vector3> OnMove;

        private bool isActive;

        public void StartGame()
        {
            isActive = true;
        }

        public void FinishGame()
        {
            isActive = false;
        }

        private void Update()
        {
            if (isActive)
            {
                HandleInputs();
            }
        }

        private void HandleInputs()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Move(Vector3.up);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                Move(Vector3.down);
            }
        }

        private void Move(Vector3 position)
        {
            OnMove?.Invoke(position);
        }
    }
}