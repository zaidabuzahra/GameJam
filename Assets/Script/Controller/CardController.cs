using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardController : MonoBehaviour
{
    bool _isHovered;
    public void HoverCard()
    {
        if (_isHovered) return;
        transform.DOLocalMoveY(transform.localPosition.y + 0.1f, 0.2f).SetEase(Ease.Linear);

        _isHovered = true;
    }
}