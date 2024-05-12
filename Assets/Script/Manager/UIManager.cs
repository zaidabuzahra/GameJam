using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject playButon, restartButton, shootText, startMenu, lastMenu;
    // public TextMeshProUGUI[] txtp1,txtp2,txtp3,txtp4;
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI points, playerName, winner;
    private void OnEnable()
    {
        CoreGameSignals.Instance.onStartGame += HideButton;
        PlayerSignals.Instance.onPlayerCanSHoot += CanShoot;
        PlayerSignals.Instance.onPlayerShoot += Shot;
        PlayerSignals.Instance.onPlayerGainPoint += Points;
        CoreGameSignals.Instance.onUpdateUI += PlayerChange;
        CoreGameSignals.Instance.onAnnounceWinner += WinScreen;
    }

    private void WinScreen()
    {
        winner.gameObject.SetActive(true);
        winner.text = "The winner is: " + gameManager.currentPlayer.name + "! Congrats";
        restartButton.SetActive(true);
    }

    public static void StartNewGame()
    {
        SceneManager.LoadScene("Level");
    }
    private void Points(int point)
    {
        //Debug.LogWarning(gameManager.currentPlayer);
        Debug.LogWarning("Points that should be added: " + point);
        int currentPoint = gameManager.GetPoint();
        Debug.LogWarning(currentPoint);
    }

    private void PlayerChange()
    {
        points.gameObject.SetActive(true);
        playerName.gameObject.SetActive(true);
        playerName.text = "It is " + gameManager.currentPlayer.name + "'s turn";
        points.text = "Points: " + gameManager.points[gameManager.currentPlayer.GetComponent<PlayerManager>().id];
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