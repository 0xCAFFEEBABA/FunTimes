using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCard", menuName = "Cards/FamilyTime")]
public class Card : ScriptableObject
{
    public string task;
    public int id;
    public Sprite image;
}
