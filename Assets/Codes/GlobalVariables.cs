using LitJson;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GlobalVariables
{
    #region Toggles and Categories
    //------------------- Toggles and Categories -------------------
    // For Family Time
    public static bool familyBool = true;
    public static string familyPath = "family";
    // For Sexy Time
    public static bool sexyBool;
    public static string sexyPath = "sexy";
    // For Macho Time
    public static bool machoBool;
    public static string machoPath = "macho";
    // For Girly Time
    public static bool girlyBool;
    public static string girlyPath = "girly";
    // For Daring Time
    public static bool daringBool;
    public static string daringPath = "daring";
    // For School Time
    public static bool schoolBool;
    public static string schoolPath = "school";
    #endregion

    #region Languages
    //------------------- Languages -------------------
    // For English language
    public static bool isEnglish = true;
    // For Greek language
    public static bool isGreek;
    #endregion

    #region Images
    //------------------- Images -------------------
    // Location for all card images for the light theme
    public static string locationLight = "cardGame/LightTheme/";
    // Location for all card images for the dark theme
    public static string locationDark = "cardGame/DarkTheme/";

    // For the Light Theme
    public static Sprite familyLightImg = Resources.Load<Sprite>(locationLight + "family");
    public static Sprite sexyLightImg = Resources.Load<Sprite>(locationLight + "sexy");
    public static Sprite machoLightImg = Resources.Load<Sprite>(locationLight + "macho");
    public static Sprite girlyLightImg = Resources.Load<Sprite>(locationLight + "girly");
    public static Sprite daringLightImg = Resources.Load<Sprite>(locationLight + "daring");
    public static Sprite schoolLightImg = Resources.Load<Sprite>(locationLight + "school");

    // For the Dark Theme
    public static Sprite familyDarkImg = Resources.Load<Sprite>(locationDark + "family");
    public static Sprite sexyDarkImg = Resources.Load<Sprite>(locationDark + "sexy");
    public static Sprite machoDarkImg = Resources.Load<Sprite>(locationDark + "macho");
    public static Sprite girlyDarkImg = Resources.Load<Sprite>(locationDark + "girly");
    public static Sprite daringDarkImg = Resources.Load<Sprite>(locationDark + "daring");
    public static Sprite schoolDarkImg = Resources.Load<Sprite>(locationDark + "school");
    #endregion

    #region JsonData
    //------------------- JSON Data -------------------
    // They are in the form of "{category}Time{language}.json"
    // So they are 6 because there are 6 categories in every language.
    // We do not need the files that are in a different language parsed.
    // For Family Time
    public static JsonData familyData;
    // For Sexy Time
    public static JsonData sexyData;
    // For Macho Time
    public static JsonData machoData;
    // For Girly Time
    public static JsonData girlyData;
    // For Daring Time
    public static JsonData daringData;
    // For School Time
    public static JsonData schoolData;
    #endregion
}
