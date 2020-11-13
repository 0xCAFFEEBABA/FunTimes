using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Build a class with all the texts we need to change 
/// </summary>
[System.Serializable]
public class Language
{
    /// <summary>
    /// the name of a game's language
    /// </summary>
    public string lang;
    /// <summary>
    /// Αll the texts we need to change
    /// </summary>
    public string Settings, LightTheme, DarkTheme,
                  FamilyCard, SexyCard, MachoCard, GirlyCard,
                  DaringCard, SchoolCard;
}
public class LanguageSettings : MonoBehaviour
{
    /// <summary>
    /// Makes an array with the languages we have
    /// </summary>
    public Language[] language;
    /// <summary>
    /// Make TextMeshProUGUI of all the texts we have in this scene
    /// </summary>
    public TextMeshProUGUI SettingsDark, SettingsLight, DarkTheme, LightTheme;
    /// <summary>
    /// Initialize an index
    /// </summary>
    public int index;

    /// <summary>
    /// If it's the first play through gets the system's language and sets it as our game's language.
    /// If the player has changed the language during their time playing, continues with the new language settings
    /// </summary>
    public void Awake()
    {
        // If it's the first playThrough
        if (GlobalVariables.Language == LanguageEnum.None)
        {
            // If the system's language is english
            if (Application.systemLanguage == SystemLanguage.English)
            {
                // Set game's language to english
                EnglishOn();
            }
            // If the system's language is greek
            else if (Application.systemLanguage == SystemLanguage.Greek)
            {
                // Set the game's language to greek
                GreekOn();
            }
            // Else if it's in another language  use english
            else
                // Set the game's language to english
                EnglishOn();
        }
        // If it's not the first playThrough
        else
        {
            // Get the previous settings
            index = PlayerPrefs.GetInt("Language", 1);
            // Change texts according to previous settings
            CurrentLanguage();
        }
    }
    /// <summary>
    /// Sets the game's  language to Greek
    /// and saves value of index in Language
    /// </summary>
    public void GreekOn()
    {
        // Set the global variable for language to greek
        GlobalVariables.Language = LanguageEnum.Greek;
        // Set the value of the index to 0
        index = 0;
        // Save the settings
        PlayerPrefs.SetInt("Language", index);
        // Change the texts to greek
        CurrentLanguage();
    }
    /// <summary>
    /// Sets the game's  language to English
    /// and saves value of index in Language
    /// </summary>
    public void EnglishOn()
    {
        // Set the global variable for language to english
        GlobalVariables.Language = LanguageEnum.English;
        // Set the value of the index to 1
        index = 1;
        // Save the settings
        PlayerPrefs.SetInt("Language", index);
        // Change the texts to english
        CurrentLanguage();
    }

    /// <summary>
    /// Change the  TextMeshProUGUI components based on the index-language- the user chooses
    /// </summary>
    public void CurrentLanguage()
    {
        // Change all the texts
        SettingsDark.text = language[index].Settings;
        DarkTheme.text = language[index].DarkTheme;
        SettingsLight.text = language[index].Settings;
        LightTheme.text = language[index].LightTheme;
    }

}
