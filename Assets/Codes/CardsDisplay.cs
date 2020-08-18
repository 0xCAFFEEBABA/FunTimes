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
    public int count;
    public int total;
    public TextMeshProUGUI countID;

    public void Start()
    {
        task.text = card.task;
        cardImage.sprite = card.image;
        countID.text = "1/500";
    }
 }   
