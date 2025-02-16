using _Project.Scripts.Gameplay.Troops;
using _Project.Scripts.Gameplay.Troops.Base;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Gameplay.UI.TroopCard
{
    public class SpawnCardController : MonoBehaviour
    {
        [SerializeField] private Image _cardCover;
        [SerializeField] private Image _troopIcon;
        [SerializeField] private Image _troopIconRadialFilled;

        private Vector3 _originalScale;
        private Button _cardButton;
        private float _cooldown;


        public void Init(Button cardButton, Sprite troopIcon, float cooldown)
        {
            _cardButton = cardButton;
            _cooldown = cooldown;
            _troopIcon.sprite = troopIcon;
            _originalScale = transform.localScale;
            _troopIconRadialFilled.color = new Color32(0, 0, 0, 208);
            _troopIconRadialFilled.sprite = troopIcon;
            _cardButton.onClick.AddListener(OnPress);
        }

        private void OnPress()
        {
            _cardButton.interactable = false;
            _cardCover.color = new Color32(161, 161, 161, 255);
            _troopIconRadialFilled.fillAmount = 1;
            _troopIconRadialFilled.DOFillAmount(0f, _cooldown).SetEase(Ease.Linear).OnComplete(() =>
            {
                _cardButton.interactable = true;
                _cardCover.color = new Color32(255, 255, 255, 255);
                transform.DOScale(_originalScale * 1.2f, 0.1f)
                    .OnComplete(() => { transform.DOScale(_originalScale, 0.1f); });
            });
        }
    }
}