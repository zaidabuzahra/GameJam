using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSignals : MonoSingletonGithub<PlayerSignals>
{ 
    public UnityAction<GameObject> onTurnEnter = delegate { };
    public UnityAction<GameObject> onTurnExit = delegate { };
    public UnityAction<GameObject> onPlayerShoot = delegate { };
}
