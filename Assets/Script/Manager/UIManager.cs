using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject playButon;
    private void OnEnable()
    {
        CoreGameSignals.Instance.onStartGame += HideButton;
    }

    private void HideButton()
    {
        playButon.SetActive(false);
    }

    public static void OnClickPlay()
    {
        CoreGameSignals.Instance.onStartGame?.Invoke();
    }
}