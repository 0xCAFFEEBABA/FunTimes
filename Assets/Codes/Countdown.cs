using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json.Linq;

public class Countdown : MonoBehaviour
{
    /// <summary>
    /// The countdown's UI element in Unity.
    /// </summary>
    public TextMeshProUGUI countdown;
    /// <summary>
    /// Keeps count of the "next card" button's clicks.
    /// </summary>
    public int count;
    /// <summary>
    /// The total number of cards in the selected categories.
    /// </summary>
    public int total;

    public void Start()
    {
        total = TotalCards();
        count = 0;

        CalculateCountdown();
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }

    /// <summary>
    /// Calculates how many cards have been played by adding 1 every time the player presses the "next card" button
    /// </summary>
    public void CalculateCountdown()
    {
        count = count + 1;
        foreach (var dataAndPool in GlobalVariables.staticDataAndPools)
        {
            var countdown = dataAndPool.Value.gameObject.transform.Find("Countdown").GetComponent<TextMeshProUGUI>();
            countdown.SetText(count.ToString() + "/" + total.ToString());
        }
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
        foreach (Data data in GlobalVariables.dataList)
        {
            // If the data is NOT null...
            if (data.ToggleBool == true)
            {
                // Sets length equal to it's previous value plus the new array's size.
                length += data.Length;
            }
        }
        // Returns the total amount of elements
        return length;
    }

}
