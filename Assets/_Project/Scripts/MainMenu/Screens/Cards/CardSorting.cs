using System.Collections.Generic;
using _Project.Scripts.Gameplay.Troops.Base;

namespace _Project.Scripts.MainMenu.Screens.Cards
{
    public class CardSorting
    {
        public void SortByName(List<TroopData> cards)
        {
            cards.Sort((a, b) => a.Config.PoolType.CompareTo(b.Config.PoolType));
        }

        public void SortByLevel(List<TroopData> cards)
        {
            cards.Sort((a, b) => a.Level.CompareTo(b.Level));
        }
    }
}