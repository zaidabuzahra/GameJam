using Newtonsoft.Json.Serialization;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] players = new GameObject[4];

    private GameObject _currentPlayer;
    private int _turnManager;
    private bool _roundPassed = false;

    private void OnEnable()
    {
        CoreGameSignals.Instance.onStartGame += PlayerTurnEnter;
        PlayerSignals.Instance.onPlayerCanSHoot += PlayerShoot;
        PlayerSignals.Instance.onTurnExit += PlayerTurnExit;
    }

    private void PlayerShoot()
    {
        Debug.Log("For some reason he is allowed to shoot");
        _currentPlayer.GetComponent<PlayerController>().CanShoot = true;
    }

    [Button]
    public void PlayerTurnEnter()
    {
        Debug.Log("Turn Enter");
        if (_roundPassed)
        {
            Debug.Log("It entered");
            _roundPassed = false;
            var lastFirst = players[0];
            bool loopFinished = false;
            for (int i = 0; i < players.Length; i++)
            {
                if (i + 1 == players.Length && !loopFinished) loopFinished = true; i = players.Length - 2;
                players[i+1] = players[i];
            }
            players[3] = lastFirst;
        }
        _currentPlayer = players[_turnManager];
        PlayerSignals.Instance.onTurnEnter?.Invoke(_currentPlayer);
    }

    [Button]
    private void PlayerTurnExit()
    {
        Debug.Log("Left");
        if (_turnManager + 1 >= players.Length)
        {
            Debug.Log("Exceeded");
            _turnManager = 0;
            _roundPassed = true;
        }
        else _turnManager++;
        Debug.Log(_turnManager);
        PlayerTurnEnter();
    }
}