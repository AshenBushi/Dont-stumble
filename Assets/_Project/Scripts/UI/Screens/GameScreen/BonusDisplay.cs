using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusDisplay : MonoBehaviour
{
    [SerializeField] private List<Sprite> _bonusIcons;
    [SerializeField] private List<Color> _bonusColors;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void ShowBonusIcon(BonusType buffType)
    {
        _image.color = _bonusColors[(int) buffType];
        _image.sprite = _bonusIcons[(int) buffType];
    }

    public void Clear()
    {
        _image.color = Color.clear;
    }
}
