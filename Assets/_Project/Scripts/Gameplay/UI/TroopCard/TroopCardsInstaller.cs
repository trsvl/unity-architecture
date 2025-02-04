using _Project.Scripts.Gameplay.Troops;
using _Project.Scripts.GameSystemLogic;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Gameplay.UI.TroopCard
{
    public class TroopCardsInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private TroopBaseConfig[] _troopConfigs; //!!!
        [SerializeField] private CardButtonController prefab;
        [SerializeField] private Transform cardsCanvasParent;


        public void Register(Container container)
        {
            foreach (var troopConfig in _troopConfigs)
            {
                var troopCard = Instantiate(prefab, cardsCanvasParent);
                var button = troopCard.GetComponent<Button>();
                var sprite = troopConfig.Prefab.GetComponent<SpriteRenderer>().sprite;
                troopCard.Init(troopConfig, Team.Player, button, sprite);
                var troopCard1 = Instantiate(prefab, cardsCanvasParent);
                var button1 = troopCard1.GetComponent<Button>();
                troopCard1.Init(troopConfig, Team.Enemy, button1, sprite);
            }
        }
    }
}
