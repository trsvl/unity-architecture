using _Project.Scripts.GameSystemLogic;
using Unity.VisualScripting;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class EventsInstaller : MonoBehaviour, IInstaller
    {
        private TroopEvents _troopEvents;
        private ColorFade _colorFade;
        private CastleEvents _castleEvents;

        
        public void Register(Container container)
        {
            _troopEvents = Instantiate(Resources.Load("Effects/TroopEvents")).GetComponent<TroopEvents>();

            _colorFade = new ColorFade();
            
            RegisterCastleEvents(container);

            SubscribeEvents();
        }

        private void TroopEvents()
        {
            //
        }

        private void RegisterCastleEvents(Container container)
        {
            var colorFade = new ColorFade();
            _castleEvents = new CastleEvents(colorFade);

            container.Bind(_castleEvents, isSingleton: true);
        }

        private void SubscribeEvents()
        {
            _troopEvents.OnTakeDamage += _colorFade.Do;
            _troopEvents.OnDeath += Factory.Instance.ReturnToPool;
            _troopEvents.OnDeath += Factory.Instance.SpawnDeathAnimation;
        }

        private void OnDestroy()
        {
            _troopEvents.OnTakeDamage -= _colorFade.Do;
            _troopEvents.OnDeath -= Factory.Instance.ReturnToPool;
            _troopEvents.OnDeath -= Factory.Instance.SpawnDeathAnimation;
            
            _castleEvents.UnsubscribeEvents();
        }
    }
}