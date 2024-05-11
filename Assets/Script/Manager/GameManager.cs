using Newtonsoft.Json.Serialization;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] players = new GameObject[4];

    private GameObject _currentPlayer;
    private int _turnManager;

    private void OnEnable()
    {
        CoreGameSignals.Instance.onStartGame += PlayerTurnEnter;
    }
    [Button]
    public void PlayerTurnEnter()
    {
        _currentPlayer = players[_turnManager];
        PlayerSignals.Instance.onTurnEnter?.Invoke(_currentPlayer);
    }

    private void PlayerTurnExit()
    {
        if (_turnManager + 1 == players.Length) _turnManager = 0;
        else _turnManager++;

        PlayerSignals.Instance.onTurnExit?.Invoke(_currentPlayer);
        PlayerTurnEnter();
    }
}