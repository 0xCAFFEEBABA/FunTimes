using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json.Linq;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI countdown;
    public int count;
    public int total;

    public void Start()
    {
        total = TotalCards();
        count = 1;
        countdown.SetText(count.ToString() + "/" + total.ToString());
    }

    /// <summary>
    /// Calculates how many cards have been played by adding 1 every time the player presses the "next card" button
    /// </summary>
    public void CalculateCountdown()
    {
        count = count + 1;
        countdown.SetText(count.ToString() + "/" + total.ToString());
        Debug.Log(TotalCards().ToString());

    }

    public int TotalCards()
    {
        int length = 0;
        foreach(Data data in GlobalVariables.dataList)
        {
            if (data.JsonData != null)
            {
                JArray cards = (JArray)data.JsonData["cards"];
                length += cards.Count;
            }
        }
        return length;
    }

    
}
