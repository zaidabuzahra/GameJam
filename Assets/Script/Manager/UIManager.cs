using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject playButon, shootText, startMenu, lastMenu;
    // public TextMeshProUGUI[] txtp1,txtp2,txtp3,txtp4;
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

    // public void EndGame(int p1,int p2,int p3,int p4){
    //     lastMenu.SetActive(true);
    //     txtp1.SetText("Player 1: " + p1);
    //     txtp1.SetText("Player 2: " + p2);
    //     txtp1.SetText("Player 3: " + p3);
    //     txtp1.SetText("Player 4: " + p4);
    // }

    private void HideButton()
    {
        playButon.SetActive(false);
        startMenu.SetActive(false);
    }

    public static void OnClickPlay()
    {
        CoreGameSignals.Instance.onStartGame?.Invoke();
    }
}