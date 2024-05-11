using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private GameObject player;
    private int randNumber;

    private void OnEnable()
    {
        PlayerSignals.Instance.onPlayerCanSHoot += GenerateNumber;
        PlayerSignals.Instance.onPlayerShoot += Shoot;
        GunSignals.Instance.onGetGunClose += GunGetClose;
        PlayerSignals.Instance.onPlayerSUrvive += Survive;
        PlayerSignals.Instance.onPlayerDie += Die;
        GunSignals.Instance.onPlayAnimation += TriggerAnim;
    }

    private void GunGetClose()
    {
        if (!player.activeSelf) return;
        Debug.Log("GunGetClose");
        transform.DOMove(player.GetComponent<PlayerManager>().GunSocket.position, 1f);
        transform.DORotate(player.GetComponent<PlayerManager>().GunSocket.rotation.eulerAngles, 1f);
        transform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 1f);
    }

    private void TriggerAnim()
    {
        animator.SetTrigger("Fire");
    }
    private void Shoot(int temp)
    {
        if (!player.activeSelf) return;
        Debug.Log("Fire");
        TriggerAnim();
        int num = Random.Range(1, 6);
        Debug.Log($"first number: {randNumber}, second number: {num}");
        if (num == randNumber) PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
        else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    private void Survive()
    {
        if (!player.activeSelf) return;
        Debug.Log("YOU SURVIVE");
        PlayerSignals.Instance.onTurnExit?.Invoke();
    }

    private void Die()
    {
        if (!player.activeSelf) return;
        Debug.Log("YOU DIE");
        PlayerSignals.Instance.onTurnExit?.Invoke();
    }

    private void GenerateNumber()
    {
        if (!player.activeSelf) return;
        Debug.Log("GenereateNumber");
        animator.SetTrigger("Reload");
        randNumber = Random.Range(1, 6);
    }
}