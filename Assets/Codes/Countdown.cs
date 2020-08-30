using UnityEngine;
using TMPro;

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

    /// <summary>
    /// Calculates the total number of cards from the selected files and basically begins counting.
    /// </summary>
    public void Start()
    {
        // Calculates the number of cards selected.
        total = TotalCards();
        // Sets count equal to 0.
        count = 0;
        // Begins the countdown.
        CalculateCountdown();
        
    }
    /// <summary>
    /// Calculates how many cards have been played by adding 1 every time the player presses the "next card" button
    /// </summary>
    public void CalculateCountdown()
    {
        // Sets count equal to its previous value plus one.
        count = count + 1;
        foreach (var stringPool in GlobalVariables.staticPoolDictionary)
        {
            var queueArray = stringPool.Value.ToArray();
            foreach (var dataPoolPair in GlobalVariables.staticDataAndPools)
            {
                if (stringPool.Key == dataPoolPair.Key.Category)
                {
                    for (int i = 0; i <= dataPoolPair.Key.Length - 1; i++)
                    {
                        // Sets countdown equal to the text object assigned for the countdown.
                        var countdown = queueArray[i].gameObject.transform.Find("Countdown").GetComponent<TextMeshProUGUI>();
                        // Sets the text equal to the current count's value / the total number of cards selected.
                        countdown.SetText(count.ToString() + "/" + total.ToString());
                    }
                }
            }
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
