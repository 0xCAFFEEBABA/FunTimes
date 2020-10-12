using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Language
{
    public string lang;
    //public string Settings, LightTheme, DarkTheme, MainMenu, Play, NextCard, FamilyCard, SexyCard, MachoCard, GirlyCard, DaringCard, SchoolCard;
    public string Settings, DarkTheme;
}
public class LanguageSettings : MonoBehaviour
{
    public Language[] language;
    /*public TextMeshProUGUI Settings, LightTheme,DarkTheme,MainMenu,Play,NextCard,FamilyCard,SexyCard,MachoCard,GirlyCard,DaringCard,SchoolCard;*/
    public TextMeshProUGUI Settings, DarkTheme;

    public int index;

    public void Start()
    {
        if (Application.systemLanguage == SystemLanguage.English)
        {
            EnglishOn();
        }
        else if (Application.systemLanguage == SystemLanguage.Greek)
        {
            GreekOn();
        }
        else
            EnglishOn();
        CurrentLanguage();
    }

    public void GreekOn()
    {
        GlobalVariables.Language = LanguageEnum.Greek;
        index = 0;
        PlayerPrefs.SetInt("Language", index);
        CurrentLanguage();
    }
    public void EnglishOn()
    {
        GlobalVariables.Language = LanguageEnum.English;
        index = 1;
        PlayerPrefs.SetInt("Language", index);
        CurrentLanguage();
    }

    public void CurrentLanguage()
    {
        Settings.text = language[index].Settings;
        //LightTheme.text = language[index].LightTheme;
        DarkTheme.text = language[index].DarkTheme;
       /* MainMenu.text = language[index].MainMenu;
        Play.text = language[index].Play;
        NextCard.text = language[index].NextCard;
        FamilyCard.text = language[index].FamilyCard;
        SexyCard.text = language[index].SexyCard;
        MachoCard.text = language[index].MachoCard;
        GirlyCard.text = language[index].GirlyCard;
        DaringCard.text = language[index].DaringCard;
        SchoolCard.text = language[index].SchoolCard;*/
    }
 
}
