using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CardsDisplay : MonoBehaviour
 {
    public Card card;
    public TextMeshProUGUI task;
    public Image cardImage;
   
    public void Start()
    {
        task.text = card.task;
        cardImage.sprite = GlobalVariables.familyLightImg;
    }

}   
