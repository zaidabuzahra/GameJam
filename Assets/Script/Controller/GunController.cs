using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private GameObject player, tableSocket;
    private int randNumber;

    private void OnEnable()
    {
        PlayerSignals.Instance.onPlayerCanSHoot += GenerateNumber;
        PlayerSignals.Instance.onPlayerShoot += Shoot;
        GunSignals.Instance.onGetGunClose += GunGetClose;
        PlayerSignals.Instance.onPlayerSUrvive += Survive;
        PlayerSignals.Instance.onPlayerDie += Die;
        GunSignals.Instance.onPlayAnimation += TriggerAnim;
        GunSignals.Instance.onGetGunBack += BackToNormal;
    }

    private void BackToNormal(GameObject gun)
    {
        StartCoroutine(BackTo(gun));
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
        animator.SetBool("Fire", true);
        animator.SetBool("GoBack", false);
    }
    private void Shoot(int temp)
    {
        if (!player.activeSelf) return;
        TriggerAnim();
        int num = Random.Range(1, 6);
        Debug.Log($"first number: {randNumber}, second number: {num}");
        if (num == randNumber) PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
        else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    IEnumerator BackTo(GameObject gun)
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("Fire", false);
        animator.SetBool("GoBack", true);
        gun.transform.DOMove(gun.GetComponent<GunController>().tableSocket.transform.position, 1f);
        gun.transform.DORotate(gun.GetComponent<GunController>().tableSocket.transform.rotation.eulerAngles, 1f);
        gun.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1f);
    }

    private void Survive()
    {
        if (!player.activeSelf) return;
        //animator.SetBool("Fire", false);
        PlayerSignals.Instance.onTurnExit?.Invoke();
    }

    private void Die()
    {
        if (!player.activeSelf) return;
        //animator.SetBool("Fire", false);
        PlayerSignals.Instance.onTurnExit?.Invoke();
    }

    private void GenerateNumber()
    {
        if (!player.activeSelf) return;
        animator.SetBool("Fire", false);
        animator.ResetTrigger("Reload");
        animator.SetTrigger("Reload");
        randNumber = Random.Range(1, 6);
    }
}