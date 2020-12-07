using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;


[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class Card : ScriptableObject
{
    public string task;
    public Sprite spriteLight;
    public Sprite spiteDark;
    public CategoryEnum category;

   
}
