using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoreGameSignals : MonoSingletonGithub<CoreGameSignals>
{
    public UnityAction onStartGame = delegate { };
    public UnityAction onResetFunction = delegate { };
    public UnityAction onResetPerTurn = delegate { };
    public UnityAction onUpdateUI = delegate { };
    public UnityAction onAnnounceWinner = delegate { };
}