using System;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.MainMenu.Footer
{
    public class FooterController
    {
        private bool _isActive = true;
        private FooterButton _activeButton;


        public void OnClick(FooterButton button, Action action = null)
        {
            if (!_isActive) return;
            if (_activeButton != null && _activeButton == button) return;

            _isActive = false;

            Color defaultColor = new Color32(147, 147, 147, 255);
            Color activeColor = new Color(1, 1, 1, 1);

            if (_activeButton != null) DoAnimation(false, defaultColor);

            _activeButton = button;
            action?.Invoke();

            DoAnimation(true, activeColor);
        }

        public void SetActiveButton(FooterButton button, MainMenuState state)
        {
            if (state != button.State) return;

            OnClick(button);
        }

        private void DoAnimation(bool isActive, Color newColor)
        {
            _activeButton.Image.color = newColor;
            _activeButton.RectTransform.DOSizeDelta(
                new Vector2(_activeButton.RectTransform.sizeDelta.x,
                    _activeButton.RectTransform.sizeDelta.y + (isActive ? 80f : -80f)),
                0.2f).SetEase(Ease.OutQuad).OnComplete(() => { _isActive = true; });
        }
    }
}