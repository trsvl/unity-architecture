using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class ColorFade
    {
        private readonly Color32 _defaultColor = new Color32(255, 255, 255, 255);
        private readonly Color32 _targetColor = new Color32(200, 0, 0, 130);

        
        public void Do(TroopBase obj)
        {
            var sprite = obj.GetComponent<SpriteRenderer>();
            sprite.DOColor(_targetColor, 0.1f).OnComplete(() => { sprite.DOColor(_defaultColor, 0.1f); });
        }
        
        public void Do(MonoBehaviour obj)
        {
            var sprite = obj.GetComponent<SpriteRenderer>();
            sprite.DOColor(_targetColor, 0.1f).OnComplete(() => { sprite.DOColor(_defaultColor, 0.1f); });
        }
    }
}