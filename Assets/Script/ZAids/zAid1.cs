using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zAid1 : MonoBehaviour
{
    public AudioSource audioSourcs;
    public AudioClip audioClia;
    public void delayedYahoo()
    {
        audioSourcs.clip = audioClia;
        audioSourcs.PlayDelayed(2);
    }
}
