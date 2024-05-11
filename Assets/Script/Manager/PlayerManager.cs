using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform GunSocket;
    public Transform[] cardSockets = new Transform[3];

    [SerializeField]
    private Animator PlayerAnimator;

    private static int points;

    private void OnEnable()
    {
        PlayerSignals.Instance.onPlayerShoot += OnPlayerShoot;
        GunSignals.Instance.onGetGunClose += OnGetGunClose;
        PlayerSignals.Instance.onPlayerGainPoint += AdjustPoint;
    }

    private void AdjustPoint(int amount)
    {
        points += amount;
    }

    private void OnGetGunClose()
    {
        Debug.Log("Works");
        //PlayerAnimator.SetTrigger("PickUp");
    }
    private void OnPlayerShoot(int temp)
    {
        //PlayerAnimator.Play(whatever);
    }

}