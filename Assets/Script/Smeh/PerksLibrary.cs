using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PerksLibrary", menuName = "PerksLibrary", order = 0)]
public class PerksLibrary : ScriptableObject 
{
    public String cardTitle;
    public String cardDescription;
    public Sprite cardImage;
    public int functionNumber;
}
