using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject playButon, shootText;
    private void OnEnable()
    {
        CoreGameSignals.Instance.onStartGame += HideButton;
        PlayerSignals.Instance.onPlayerCanSHoot += CanShoot;
        PlayerSignals.Instance.onPlayerShoot += Shot;
    }

    private void Shot(int temp)
    {
        Debug.Log("TextUpdated");
        shootText.SetActive(false);
    }

    private void CanShoot()
    {
        shootText.SetActive(true);
    }

    private void HideButton()
    {
        playButon.SetActive(false);
    }

    public static void OnClickPlay()
    {
        CoreGameSignals.Instance.onStartGame?.Invoke();
    }
}