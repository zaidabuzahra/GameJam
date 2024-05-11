using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Mirror.Examples.Basic;

public class CustomNM : NetworkManager
{
    public override void OnClientConnect()
    {
        base.OnClientConnect();

        Debug.Log("Client succesfuly connected to server!");
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        Debug.Log($"There are {numPlayers} connected to server!");

        SyncingData playerColor = conn.identity.GetComponent<SyncingData>();
        playerColor.SetDisplayColor(new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f)));

    }
}
