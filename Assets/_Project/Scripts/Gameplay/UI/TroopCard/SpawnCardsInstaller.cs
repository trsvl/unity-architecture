using _Project.Scripts.GameSystemLogic;
using _Project.Scripts.MainMenu.Screens;
using _Project.Scripts.Utils.DTOs;
using _Project.Scripts.Utils.Installers;
using Unity.VisualScripting;
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
            var playerTroops = ProjectData.Instance.TroopsDataController.LoadSelectedPlayerTroops();
            
            foreach (var data in playerTroops)
            {
                var troopCard = Instantiate(prefab, cardsCanvasParent);
                var button = troopCard.GetComponent<Button>();
                var sprite = data.Troop  .Prefab.GetComponent<SpriteRenderer>().sprite;
                troopCard.Init(data.Troop.Prefab, Team.Player, button, sprite);
                var troopCard1 = Instantiate(prefab, cardsCanvasParent);
                var button1 = troopCard1.GetComponent<Button>();
                troopCard1.Init(data.Troop.Prefab, Team.Enemy, button1, sprite);
            }
        }
    }
}
