using Sirenix.OdinInspector;
using UnityEngine;
using DG.Tweening;
using UnityEditor;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] players = new GameObject[4];

    private GameObject _currentPlayer;
    private int _turnManager;
    private bool _roundPassed = false, firstTime = true;

    [SerializeField]
    private GameObject cam;

    private void OnEnable()
    {
        CoreGameSignals.Instance.onStartGame += PlayerTurnEnter;
        PlayerSignals.Instance.onTurnExit += PlayerTurnExit;
    }

    [Button]
    public void PlayerTurnEnter()
    {
        Debug.Log("Turn Enter");
        _currentPlayer = players[_turnManager];
        if (firstTime)
        {
            PlayerSignals.Instance.onTurnEnter?.Invoke(_currentPlayer);
            firstTime = false;
            return;
        }
        if (_roundPassed)
        {
            Debug.Log("It entered");
            _roundPassed = false;
            var lastFirst = players[0];
            Debug.Log(players[1].name);
            for (int i = 1; i < players.Length; i++)
            {;
                players[i-1] = players[i];
            }
            players[3] = lastFirst;
            players[_turnManager].SetActive(true);
            Debug.Log(players[0].name);
            _currentPlayer = players[_turnManager];
            Debug.Log(players[3].name);
            PlayerSignals.Instance.onTurnEnter?.Invoke(_currentPlayer);
            return;
        }
        players[_turnManager].SetActive(true);
        GunSignals.Instance.onGetGunClose?.Invoke();
        PlayerSignals.Instance.onPlayerCanSHoot?.Invoke();
    }

    private void RotateCamera()
    {
        int y = 0;
        if (_roundPassed) y = 180;
        else y = 90;
        Debug.Log(cam.transform.rotation.y);
        cam.transform.DORotate(new Vector3(0, (cam.transform.rotation.y) + y, 0), 1f, RotateMode.FastBeyond360).SetRelative();
    }
    private void PlayerTurnExit()
    {
        StartCoroutine(ShootTimer());
    }

    IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Left");
        players[_turnManager].SetActive(false);
        if (_turnManager + 1 >= players.Length)
        {
            Debug.Log("Exceeded");
            _turnManager = 0;
            _roundPassed = true;
        }
        else _turnManager++;
        Debug.Log(_turnManager);
        RotateCamera();
        PlayerTurnEnter();
    }
}