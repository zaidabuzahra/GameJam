using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform GunSocket;
    public Transform[] cardSockets = new Transform[3];
    public Animator PlayerAnimator;

    private void OnEnable()
    {
        PlayerSignals.Instance.onPlayerShoot += OnPlayerShoot;
        GunSignals.Instance.onGetGunClose += OnGetGunClose;
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
