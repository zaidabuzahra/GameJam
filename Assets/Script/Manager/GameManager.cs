using Sirenix.OdinInspector;
using UnityEngine;
using DG.Tweening;
using UnityEditor;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] players = new GameObject[4];
    private int[] points = new int[4];

    public GameObject currentPlayer { get; private set; }
    private int _turnManager;
    private bool _roundPassed = false, firstTime = true;

    [SerializeField]
    private GameObject cam;

    private void OnEnable()
    {
        CoreGameSignals.Instance.onStartGame += PlayerTurnEnter;
        PlayerSignals.Instance.onTurnExit += PlayerTurnExit;
        PlayerSignals.Instance.onPlayerGainPoint += AdjustPoint;
    }

    public int GetPoint()
    {
        return points[_turnManager];
    }

    public void RoundPass()
    {
        _roundPassed = true;
    }

    public void AdjustPoint(int amount)
    {
        if (amount == 0) points[currentPlayer.GetComponent<PlayerManager>().id] = 0;
        else if (amount >= 4000) points[currentPlayer.GetComponent<PlayerManager>().id] += points[currentPlayer.GetComponent<PlayerManager>().id    ];
        else
        {
            Debug.LogWarning(currentPlayer.GetComponent<PlayerManager>().id);
            points[currentPlayer.GetComponent<PlayerManager>().id] += amount;
        }
        Debug.LogWarning($"IN PLAYER MANAGER: {GetPoint()}");

        if(points[currentPlayer.GetComponent<PlayerManager>().id] >=4000){
            Debug.Log("Player " + (currentPlayer.GetComponent<PlayerManager>().id + 1) + " is the winner!!");
        }
    }

    [Button]
    public void PlayerTurnEnter()
    {
        Debug.Log("-------Enter Turn Enter------");
        currentPlayer = players[_turnManager];
        if (firstTime)
        {
            PlayerSignals.Instance.onTurnEnter?.Invoke(currentPlayer);
            firstTime = false;
            return;
        }
        if (_roundPassed)
        {
            Debug.Log("-----Round");
            _roundPassed = false;
            var lastFirst = players[0];
            for (int i = 1; i < players.Length; i++)
            {;
                players[i-1] = players[i];
            }
            players[3] = lastFirst;
            players[_turnManager].SetActive(true);
            currentPlayer = players[_turnManager];
            CoreGameSignals.Instance.onResetFunction?.Invoke();
            PlayerSignals.Instance.onTurnEnter?.Invoke(currentPlayer);
            return;
        }
        Debug.Log("-----Next Player");
        players[_turnManager].SetActive(true);
        GunSignals.Instance.onGetGunClose?.Invoke();
        PlayerSignals.Instance.onPlayerCanSHoot?.Invoke();
        Debug.Log("-------Leave TurnEnter------");
    }

    private void RotateCamera()
    {
        int y = 0;
        if (_roundPassed) y = 180;
        else y = 90;
        cam.transform.DORotate(new Vector3(0, (cam.transform.rotation.y) + y, 0), 1f, RotateMode.FastBeyond360).SetRelative();
    }
    private void PlayerTurnExit()
    {
        StartCoroutine(ShootTimer());
    }

    IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("-----Enter TurnExit-----");
        CoreGameSignals.Instance.onResetPerTurn?.Invoke();
        GunSignals.Instance.onGetGunBack?.Invoke(players[_turnManager].GetComponent<PlayerManager>().Gun);
        players[_turnManager].SetActive(false);
        if (_turnManager + 1 >= players.Length)
        {
            Debug.Log("Exceeded");
            _turnManager = 0;
            _roundPassed = true;
        }
        else _turnManager++;
        Debug.Log(_turnManager);
        Debug.Log("------Leave TurnExit-----");
        RotateCamera();
        PlayerTurnEnter();
    }
}