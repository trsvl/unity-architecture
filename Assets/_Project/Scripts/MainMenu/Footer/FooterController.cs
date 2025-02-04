using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.MainMenu.Footer
{
    public class FooterController
    {
        private bool _isActive = true;
        private FooterButton _activeButton;


        public void OnClick(FooterButton button)
        {
            if (!_isActive) return;
            if (_activeButton != null && _activeButton == button) return;

            _isActive = false;
            
            if (_activeButton != null) Reset();
            _activeButton = button;

            Color activeColor = new Color(1, 1, 1, 1);
            button.Image.color = activeColor;
            button.RectTransform
                .DOSizeDelta(new Vector2(button.RectTransform.sizeDelta.x, button.RectTransform.sizeDelta.y + 80f),
                    0.2f).SetEase(Ease.OutQuad).OnComplete(() => { _isActive = true; });
        }

        private void Reset()
        {
            Color defaultColor = new Color32(147, 147, 147, 255);
            _activeButton.Image.color = defaultColor;
            _activeButton.RectTransform.DOSizeDelta(
                new Vector2(_activeButton.RectTransform.sizeDelta.x, _activeButton.RectTransform.sizeDelta.y - 80f),
                0.2f).SetEase(Ease.OutQuad);
        }
    }
}