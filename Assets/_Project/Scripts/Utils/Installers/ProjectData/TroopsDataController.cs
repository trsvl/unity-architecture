using System;
using _Project.Scripts.Gameplay.Troops;
using UnityEngine;

namespace _Project.Scripts.Utils.Installers
{
    public class TroopsDataController
    {
        private TroopBase[] AllTroops { get; set; } // create new SO AllTroops

        public TroopBase[] TroopsArmy { get; private set; } = new TroopBase[3];


        public void LoadData()
        {
            var troopsArmy = PlayerPrefs.GetString("TroopsArmy", "0");
            TroopsArmy = ParseTroopArmyData(troopsArmy);
        }

        private TroopBase[] ParseTroopArmyData(string data)
        {
            int[] troopsArmyInt = Array.ConvertAll(data.Split(','), int.Parse);
            TroopBase[] troopArmy = new TroopBase[troopsArmyInt.Length];

            for (int i = 0; i < troopsArmyInt.Length; i++)
            {
                troopArmy[i] = AllTroops[troopsArmyInt[i]];
            }

            return troopArmy;
        }
    }
}