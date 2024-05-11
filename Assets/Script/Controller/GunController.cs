using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private int randNumber;

    private void OnEnable()
    {
        PlayerSignals.Instance.onPlayerCanSHoot += GenerateNumber;
        PlayerSignals.Instance.onPlayerShoot += Shoot;
    }

    private void Shoot()
    {
        int num = Random.Range(1, 6);
        if (num == randNumber) PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
        else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    private void Survie()
    {

    }

    private void Die()
    {

    }

    private void GenerateNumber()
    {
        randNumber = Random.Range(1, 6);
    }
}