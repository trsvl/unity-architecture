using System;
using System.Collections.Generic;
using _Project.Scripts.Gameplay;
using _Project.Scripts.Gameplay.Troops;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CardButtonController : MonoBehaviour
{
    [SerializeField] private Image _cardCover;
    [SerializeField] private Image _troopRadialFilled;
    [SerializeField] private float _cooldown;
    [SerializeField] private AttackingTroopConfig troop;
    [SerializeField] private Team team;
    

    private Vector3 _originalScale;
    private Button _cardButton;

    private void Awake()
    {
        _cardButton = GetComponent<Button>(); //!!!
        _originalScale = transform.localScale;
        _troopRadialFilled.color = new Color32(0, 0, 0, 208);
        _cardButton.onClick.AddListener(OnPress);
    }

    public void Init(Button cardButton)
    {
        _cardButton = cardButton;
    }

    private void OnPress()
    {
        Factory.Instance.Spawn(troop, team);//!!!
        
        _cardButton.interactable = false;
        _cardCover.color = new Color32(161, 161, 161, 255);
        _troopRadialFilled.fillAmount = 1;
        _troopRadialFilled.DOFillAmount(0f, _cooldown).SetEase(Ease.Linear).OnComplete(() =>
        {
            _cardButton.interactable = true;
            _cardCover.color = new Color32(255, 255, 255, 255);
            transform.DOScale(_originalScale * 1.2f, 0.1f)
                .OnComplete(() => { transform.DOScale(_originalScale, 0.1f); });
        });
    }
}