using _Project.Scripts.GameSystemLogic;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Buildings
{
    public class Castle : MonoBehaviour, IDamageable
    {
        [SerializeField] private float health = 10f;
        public Team Team { get; private set; }

        private GameplayStateObserver _gameplayStateObserver;


        public void Init(Team team)
        {
            Team = team;
        }

        public void TakeDamage(float damage)
        {
            health -= damage;

            if (!(health <= 0)) return;

            print(Team == Team.Player ? "Defeat!" : "Win!");

            _gameplayStateObserver.FinishGame();
        }
    }
}