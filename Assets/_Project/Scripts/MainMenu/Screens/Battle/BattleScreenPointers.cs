using _Project.Scripts.Utils.Installers;
using UnityEngine.UI;

namespace _Project.Scripts.MainMenu.Screens.Battle
{
    public class BattleScreenPointers
    {
        private readonly Button _leftPointer;
        private readonly Button _rightPointer;
        private readonly LevelDataController _levelDataController;


        public BattleScreenPointers(Button leftPointer, Button rightPointer, LevelDataController levelDataController)
        {
            _leftPointer = leftPointer;
            _rightPointer = rightPointer;
            _levelDataController = levelDataController;
            
            CheckLeftPointer();
            CheckRightPointer();
        }

        public void LeftPointerClickListener()
        {
            _levelDataController.CurrentLevel -= 1;

            CheckLeftPointer();
            CheckRightPointer();
        }

        public void RightPointerClickListener()
        {
            _levelDataController.CurrentLevel += 1;

            CheckLeftPointer();
            CheckRightPointer();
        }

        private void CheckLeftPointer()
        {
            _leftPointer.interactable = _levelDataController.CurrentLevel > 1;
        }

        private void CheckRightPointer()
        {
            _rightPointer.interactable = _levelDataController.CurrentLevel < _levelDataController.MaxLevels;
        }
    }
}