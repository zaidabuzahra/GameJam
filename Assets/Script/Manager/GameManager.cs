using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] players = new GameObject[4];

    private GameObject _currentPlayer;
    private int _turnManager;

    private void PlayerTurnEnter(int index)
    {
        _currentPlayer = players[index];
        
    }

    private void PlayerShoot()
    {

    }

    private void PlayerTurnExit()
    {
        if (_turnManager + 1 == players.Length) _turnManager = 0;
        else _turnManager++;

        PlayerTurnEnter(_turnManager);
    }
}