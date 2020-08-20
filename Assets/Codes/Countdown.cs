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
    }

    /// <summary>
    /// Calculates the number of elements in every JSON file's array and adds them.
    /// Also sets for every data their length equal to length.
    /// </summary>
    /// <returns>The total number of tasks from the selected categories</returns>
    public int TotalCards()
    {
        // By default the length is 0
        int length = 0;
        // For each data in the dataList...
        foreach(Data data in GlobalVariables.dataList)
        {
            // If the data is NOT null...
            if (data.JsonData != null)
            {
                // Creates an array that contains the elements of the JSON file's array.
                JArray cards = (JArray)data.JsonData["cards"];
                // Sets data's length equal the size of the array.
                data.Length = cards.Count;
                // Sets length equal to it's previous value plus the new array's size.
                length += cards.Count;
            }
        }
        // Returns the total amount of elements
        return length;
    }

    
}
