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

    private int points;

    private void OnEnable()
    {
        PlayerSignals.Instance.onPlayerShoot += OnPlayerShoot;
        GunSignals.Instance.onGetGunClose += OnGetGunClose;
        PlayerSignals.Instance.onPlayerGainPoint += AdjustPoint;
    }

    public int GetPoint()
    {
        return this.points;
    }

    public void AdjustPoint(int amount)
    {
        if (amount == 0) this.points = 0;
        else if (amount >= 4000) this.points += this.points;
        else
        {
            this.points += amount;
        }
        Debug.LogWarning($"IN PLAYER MANAGER: {this.points}");
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