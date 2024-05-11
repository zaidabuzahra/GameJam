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

    [Button]
    public void PlayerTurnEnter(int index)
    {
        _currentPlayer = players[0];
        PlayerSignals.Instance.onTurnEnter?.Invoke(_currentPlayer);
        //PlayerShoot();
    }

    private void PlayerShoot()
    {
        PlayerSignals.Instance.onPlayerShoot?.Invoke(_currentPlayer);
        PlayerTurnExit();
    }

    private void PlayerTurnExit()
    {
        if (_turnManager + 1 == players.Length) _turnManager = 0;
        else _turnManager++;

        PlayerSignals.Instance.onTurnExit?.Invoke(_currentPlayer);
        PlayerTurnEnter(_turnManager);
    }
}