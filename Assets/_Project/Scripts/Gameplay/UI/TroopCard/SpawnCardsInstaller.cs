using _Project.Scripts.Gameplay.Troops.Base;
using _Project.Scripts.GameSystemLogic;
using _Project.Scripts.Utils.Installers;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Gameplay.UI.TroopCard
{
    public class SpawnCardsInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private SpawnCardController prefab;
        [SerializeField] private Transform cardsCanvasParent;


        public void Register(Container container)
        {
            var troopsDataController = new TroopsDataController();
            troopsDataController.LoadAllTroops();

            foreach (TroopData data in troopsDataController.TroopArmy)
            {
                TroopBaseConfig config = data.Config;

                var troopCard = Instantiate(prefab, cardsCanvasParent);
                var button = troopCard.GetComponent<Button>();
                var sprite = config.Prefab.GetComponent<SpriteRenderer>().sprite;
                var cooldown = config.SpawnCooldown;
                troopCard.Init(button, sprite, cooldown);

                var troopCard1 = Instantiate(prefab, cardsCanvasParent);
                var button1 = troopCard1.GetComponent<Button>();
                troopCard1.Init(button, sprite, cooldown);

                int level = data.Level;
                button.onClick.AddListener(() => SpawnTroop(config, Team.Player, level));
                button1.onClick.AddListener(() => SpawnTroop(config, Team.Enemy, level));
            }
        }

        private void SpawnTroop(TroopBaseConfig config, Team team, int level)
        {
            Factory.Instance.Spawn(config, team, level);
        }
    }
}