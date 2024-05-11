using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardController : MonoBehaviour
{
    public bool Played;
    bool _isHovered;
    Vector3 _originalPos;

    public void SetPos(Vector3 pos)
    {
        _originalPos = pos;
    }
    public void HoverCard()
    {
        if (_isHovered || Played) return;
        transform.DOLocalMoveY(transform.localPosition.y + 0.1f, 0.2f).SetEase(Ease.Linear);

        _isHovered = true;
    }

    public void MoveBack()
    {
        if (Played) return;
        transform.DOLocalMoveY(_originalPos.y, 0.2f).SetEase(Ease.Linear);
        _isHovered = false;
    }
}