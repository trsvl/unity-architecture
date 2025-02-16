using System;
using _Project.Scripts.Gameplay.Troops.Base;

namespace _Project.Scripts.MainMenu.Screens.Cards
{
    public class CardSorting
    {
        public void SortByName(TroopData[] cards)
        {
            Array.Sort(cards, (a, b) => a.Config.PoolType.CompareTo(b.Config.PoolType));
        }

        public void SortByLevel(TroopData[] cards)
        {
            Array.Sort(cards, (a, b) => a.Level.CompareTo(b.Level));
        }
    }
}