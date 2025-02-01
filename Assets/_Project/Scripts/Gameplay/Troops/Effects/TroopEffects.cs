using System;
using _Project.Scripts.Utils;

namespace _Project.Scripts.Gameplay.Troops
{
    public class TroopEffects : Singleton<TroopEffects>
    {
        public event Action<TroopBase> OnTakeDamage;
        public event Action<TroopBase> OnDeath;


        public void TakeDamage(TroopBase troop)
        {
            OnTakeDamage?.Invoke(troop);
        }

        public void Death(TroopBase troop)
        {
            OnDeath?.Invoke(troop);
        }
    }
}