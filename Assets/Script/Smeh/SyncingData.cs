using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SyncingData : NetworkBehaviour
{
    [SyncVar(hook = "HandleDisplayColorChange")] [SerializeField] private Color displayColor;

    [SerializeField] private MeshRenderer meshRenderer;

    [Server]
    public void SetDisplayColor(Color newColor){
        displayColor = newColor;
    }

    private void HandleDisplayColorChange(Color oldColor, Color newColor){
        meshRenderer.material.color = newColor;
    }
}
