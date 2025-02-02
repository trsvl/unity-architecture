using _Project.Scripts.Gameplay.Troops;
using _Project.Scripts.GameSystemLogic;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Buildings
{
    public class Castle : MonoBehaviour, IDamageable
    {
        private float _health;
        private Team _team;
        private CastleEvents _castleEvents;
        private GameplayStateObserver _gameplayStateObserver;


        public void Init(float health, Team team, CastleEvents castleEvents,
            GameplayStateObserver gameplayStateObserver)
        {
            _health = health;
            _team = team;
            _castleEvents = castleEvents;
            _gameplayStateObserver = gameplayStateObserver;
            gameObject.tag = _team.ToString();
        }

        public void TakeDamage(float damage)
        {
            if (_health > 0)
            {
                _health -= damage;
                _castleEvents.TakeDamage(this);
            }
            else
            {
                Debug.LogWarning(_team == Team.Player ? "Defeat!" : "Win!");
                _gameplayStateObserver.FinishGame();
            }
        }
    }
}