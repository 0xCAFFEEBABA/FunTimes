using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class KeepTheme : MonoBehaviour
{
    // In our mainMenu Scene...
    // Checks which theme is activated and saves it in 
    // Before destroying this scene.
    /// <summary>
    /// In our mainMenu Scene... Checks which theme is activated and...
    /// Saves it in <see cref="GlobalVariables.Theme"/> before destroying this scene.
    /// </summary>
    public void OnDestroy()
    { 
        // Finds the gameObject that represents the dark theme
        var darkTheme = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag(StringsAndConsants.darkTheme));
        // Finds the gameObject that represents the light theme.
        var lightTheme = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag(StringsAndConsants.lightTheme));
       
        // If the light theme is active...
        if (lightTheme.activeSelf)
        {
            GlobalVariables.Theme = ThemeEnum.LightTheme;
        }
            
        // Else if the dark theme is active...
        else if (darkTheme.activeSelf)
            GlobalVariables.Theme = ThemeEnum.DarkTheme;
        // Else...
        else
            // Sets by default theme to light
            GlobalVariables.Theme = ThemeEnum.LightTheme;
    }


}
