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
            Debug.Log(lastFirst);
            for (int i = 1; i < players.Length; i++)
            {;
                players[i] = players[i-1];
            }
            players[3] = lastFirst;
            players[_turnManager].SetActive(true);
            Debug.Log(players[3]);
            PlayerSignals.Instance.onTurnEnter?.Invoke(_currentPlayer);
            return;
        }
        players[_turnManager].SetActive(true);
        PlayerSignals.Instance.onPlayerCanSHoot?.Invoke();
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
        cam.transform.DORotate(cam.transform.rotation.eulerAngles + new Vector3(0f, 90f, 0f), 1f);
        PlayerTurnEnter();
    }
}