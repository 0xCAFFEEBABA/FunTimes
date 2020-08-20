using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCard", menuName = "Cards")]
public class Card : ScriptableObject
{
    public string task;
    public Sprite spriteLight;
    public Sprite spiteDark;
}
