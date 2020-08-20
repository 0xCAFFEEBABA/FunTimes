using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CardsDisplay : MonoBehaviour
 {
    public TextMeshProUGUI task;
    public Image cardImage;

    public void Start()
    {
        task.text = "blahblah";
        //cardImage.sprite = GlobalVariables.staticDataAndPools.Value .prefab.spriteLight;
    }
}   
