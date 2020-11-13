using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LanguageManager2 : MonoBehaviour
{
    ///<summary>
    /// Make an array with the languages we have
    ///</summary>
    public Language[] language;

    ///<summary>
    /// Make TextMeshProUGUI of all the texts we have in this scene
    ///</summary>
    public TextMeshProUGUI FamilyCard, SexyCard, MachoCard, GirlyCard, DaringCard, SchoolCard;

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

    //<summary>  
    /// Change the  TextMeshProUGUI based on the pointer (language) the user chooses
    ///</summary>
    public void CurrentLanguage()
    {
        // Takes the category's text component and sets it equal to the text we inserted in unity.
        FamilyCard.text = language[pointer].FamilyCard;
        SexyCard.text = language[pointer].SexyCard;
        MachoCard.text = language[pointer].MachoCard;
        GirlyCard.text = language[pointer].GirlyCard;
        DaringCard.text = language[pointer].DaringCard;
        SchoolCard.text = language[pointer].SchoolCard;
    }

}

