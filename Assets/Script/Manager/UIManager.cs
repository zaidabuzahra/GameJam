using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject playButon, shootText;
    [SerializeField] TextMeshProUGUI points;
    private void OnEnable()
    {
        CoreGameSignals.Instance.onStartGame += HideButton;
        PlayerSignals.Instance.onPlayerCanSHoot += CanShoot;
        PlayerSignals.Instance.onPlayerShoot += Shot;
        PlayerSignals.Instance.onPlayerGainPoint += Points;
    }

    private void Points(int point)
    {
        points.text = point.ToString();
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