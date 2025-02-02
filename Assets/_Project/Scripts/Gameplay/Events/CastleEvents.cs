using System;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class CastleEvents
    {
        private readonly ColorFade _colorFade;
        
        public event Action<MonoBehaviour> OnTakeDamage;


        public CastleEvents(ColorFade colorFade)
        {
            _colorFade = colorFade;
            
            SubscribeEvents();
        }

        public void TakeDamage(MonoBehaviour gameObject)
        {
            OnTakeDamage?.Invoke(gameObject);
        }

        private void SubscribeEvents()
        {
            OnTakeDamage += _colorFade.Do;
        }

        public void UnsubscribeEvents()
        {
            OnTakeDamage -= _colorFade.Do;
        }
    }
}