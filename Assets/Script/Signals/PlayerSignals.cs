using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSignals : MonoSingletonGithub<PlayerSignals>
{ 
    public UnityAction<GameObject> onTurnEnter = delegate { };
    public UnityAction onTurnExit = delegate { };
    public UnityAction<int> onPlayerShoot = delegate { };
    public UnityAction<GameObject> onPlayerChoseCard = delegate { };
    public UnityAction onPlayerCanSHoot = delegate { };
    public UnityAction onPlayerCanChoose = delegate { };
    public UnityAction onPlayerSUrvive = delegate { };
    public UnityAction onPlayerDie = delegate { };
    public UnityAction<int> onPlayerGainPoint = delegate { };
    public UnityAction<int> AdjustPoints = delegate { };
}
