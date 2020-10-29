using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultDeck : MonoBehaviour
{
    /// <summary>
    /// When navigated to the "mainMenu" sets the defaults values for toggles and opens the JSON files.
    /// </summary>
    public void Start()
    {
        // Creates a List of type Data that contains all categories data.
        // *This happens only at the start of the game where the default values are set. 
        // Every other time the "mainMenu" scene is visited the values are the ones set by the user in the "chooseDecks" scene*
        GlobalVariables.CreateDataList();
    }

}
