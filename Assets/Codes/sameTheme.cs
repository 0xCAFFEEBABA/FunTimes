using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class sameTheme : MonoBehaviour
{
    public void Start()
    {
        // Finds the gameObject that represents the dark theme
        var darkTheme = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("DarkTheme"));
        // Finds the gameObject that represents the light theme
        var lightTheme = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("LightTheme"));

        // Loads the theme data from PlayerPrefs
        // If there is no value set for theme the default is 0 ( light theme ).
        var themeInt = PlayerPrefs.GetInt("theme", 0);
       // Debug.Log(themeInt);
        // If theme is 0...
        if (themeInt == 0)
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
