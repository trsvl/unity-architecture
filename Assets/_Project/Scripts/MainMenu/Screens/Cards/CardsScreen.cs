using System.Collections.Generic;
using _Project.Scripts.Gameplay.Troops;
using _Project.Scripts.Utils.Installers;
using UnityEngine;

namespace _Project.Scripts.MainMenu.Screens
{
    public class CardsScreen : MainMenuScreen
    {
        private GameObject TroopCardPrefab;
        
        
        public void Init()
        {
            var troopsController = ProjectData.Instance.TroopsDataController;

            List<TroopBase> unlockedTroops = new();
            
            foreach (TroopBase troop in troopsController.AllTroops)
            {
                //if (troop)
            }
        }

        public override void Enable()
        {
            
        }

        public override void Disable()
        {
        }
    }
}