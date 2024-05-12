using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform GunSocket;
    public Transform[] cardSockets = new Transform[3];
    public GameObject Gun;

    [SerializeField]
    private Animator PlayerAnimator;

    private static int points;

    private void OnEnable()
    {
        PlayerSignals.Instance.onPlayerShoot += OnPlayerShoot;
        GunSignals.Instance.onGetGunClose += OnGetGunClose;
        PlayerSignals.Instance.onPlayerGainPoint += AdjustPoint;
    }

    public int GetPoint()
    {
        return points;
    }

    public void AdjustPoint(int amount)
    {
        if (amount == 0) points = 0;
        else if (amount >= 4000) points += points;
        else
        {
            points += amount;
        }
    }

    private void OnGetGunClose()
    {
        //PlayerAnimator.SetTrigger("PickUp");
    }
    private void OnPlayerShoot(int temp)
    {
        //PlayerAnimator.Play(whatever);
    }

}