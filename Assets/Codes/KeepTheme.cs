using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class KeepTheme : MonoBehaviour
{
    // In our mainMenu Scene...
    // Checks which theme is activated and saves it in the player's device
    // Before destroying this scene.
    public void OnDestroy()
    { 
        // Finds the gameObject that represents the dark theme
        var darkTheme = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("DarkTheme"));
        // Finds the gameObject that represents the light theme.
        var lightTheme = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("LightTheme"));
       
        // If the light theme is active...
        if (lightTheme.activeSelf)
            // Sets inside PlayerPrefs theme = 0
            PlayerPrefs.SetInt("theme", 0);
        // Else if the dark theme is active...
        else if (darkTheme.activeSelf)
            // Sets inside PlayerPrefs theme = 1
            PlayerPrefs.SetInt("theme", 1);
        // Else...
        else
            // Sets by default theme = 0
            PlayerPrefs.SetInt("theme", 0);
    }


}
