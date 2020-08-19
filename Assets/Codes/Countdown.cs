using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI countdown;
    public int count;
    public int total;
    public Button button;

    public void Start()
    {
        count = 1;
        countdown.SetText(count.ToString());
    }

    /// <summary>
    /// Calculates how many cards have been played by adding 1 every time the player presses the "next card" button
    /// </summary>
    public void CalculateCountdown()
    {
        count += 1;
        Debug.Log(count);
    }

    public void TotalCards()
    {

    }

    
    public void GetCountDown()
    {
        Button nextCardBtn = button.GetComponent<Button>();
        nextCardBtn.onClick.AddListener(CalculateCountdown);
        countdown.SetText(count.ToString());

    }
}
