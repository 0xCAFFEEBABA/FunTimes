using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DefaultDeck : MonoBehaviour
{
    /// <summary>
    /// When navigated to the "mainMenu" sets the defaults values for toggles and opens the JSON files.
    /// </summary>
    public void Start()
    {
        if (GlobalVariables.fromSideMenu == true)
        {
            GlobalVariables.fromSideMenu = false;
            // Find game object with name: MainMenu
            var mainMenu = Resources.FindObjectsOfTypeAll<GameObject>();
            foreach (var gameObject in mainMenu)
            {
                if (gameObject.CompareTag("MainMenu"))
                    // Deactivates mainMenu
                    gameObject.SetActive(false);
                else if (gameObject.CompareTag("SettingsMenu"))
                    // Deactivates mainMenu
                    gameObject.SetActive(true);
                else
                    continue;
            }
        }

        // Creates a List of type Data that contains all categories data.
        // *This happens only at the start of the game where the default values are set. 
        // Every other time the "mainMenu" scene is visited the values are the ones set by the user in the "chooseDecks" scene*
        GlobalVariables.CreateDataList();

    }

}
