using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunSignals : MonoSingletonGithub<GunSignals>
{
    public UnityAction onGetGunClose = delegate { };
    public UnityAction onPlayAnimation = delegate { };
}
