using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject playButon, shootText;
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI points, playerName;
    private void OnEnable()
    {
        CoreGameSignals.Instance.onStartGame += HideButton;
        PlayerSignals.Instance.onPlayerCanSHoot += CanShoot;
        PlayerSignals.Instance.onPlayerShoot += Shot;
        PlayerSignals.Instance.onPlayerGainPoint += Points;
    }

    private void Points(int point)
    {
        playerName.text = gameManager.currentPlayer.name;
        //Debug.LogWarning(gameManager.currentPlayer);
        Debug.LogWarning("Points that should be added: " + point);
        int currentPoint = gameManager.GetPoint();
        Debug.LogWarning(currentPoint);
        points.text = (currentPoint + point).ToString();
    }

    private void Shot(int temp)
    {
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