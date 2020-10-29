using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SameTheme : MonoBehaviour
{
    public void Start()
    {
        // Finds the gameObject that represents the dark theme
        var darkTheme = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("DarkTheme"));
        // Finds the gameObject that represents the light theme
        var lightTheme = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("LightTheme"));

        // If light them is active in the mainMenu scene...
        if (GlobalVariables.Theme == ThemeEnum.LightTheme)
        {
            // Activates the Light Theme...
            lightTheme.SetActive(true);
            // Deactivates the Dark Theme.
            darkTheme.SetActive(false);
        }
        // Else...
        else
        {
            // Deactivates the Light Theme and...
            lightTheme.SetActive(false);
            // Activates the Dark Theme.
            darkTheme.SetActive(true);
        }
    }
}
