using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageManager3 : MonoBehaviour
{
    ///<summary>
    /// Make an array with the languages we have
    ///</summary>
    public Language[] language;

    ///<summary>
    /// Make TextMeshProUGUI of all the texts we have in this scene
    ///</summary>
    public TextMeshProUGUI Settings,ChooseDecks,SuggestACard,RateUs;

    ///<summary>
    /// Initialize an index
    ///</summary>
    public int pointer;

    ///<summary>  
    /// When this scene starts get the previous language settings 
    ///</summary>
    void Start()
    {
        // Get the previous scene's language settings and save it in pointer
        pointer = PlayerPrefs.GetInt("Language", 1);
        // Call the method that changes the texts based on the language settings
        CurrentLanguage();
    }

    ///<summary>  
    /// Change the  TextMeshProUGUI based on the pointer (language) the user chooses
    ///</summary>
    public void CurrentLanguage()
    {
        // Takes the category's text component and sets it equal to the text we inserted in unity.
        Settings.text = language[pointer].SettingsSideMenu;
        ChooseDecks.text = language[pointer].ChooseDecksSideMenu;
        SuggestACard.text = language[pointer].SuggestACardSideMenu;
        RateUs.text = language[pointer].RateUsSideMenu;
    }


}
