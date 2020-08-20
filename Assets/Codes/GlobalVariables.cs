using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GlobalVariables
{
    public static Data familyTime = new Data();
    public static Data sexyTime = new Data();
    public static Data machoTime = new Data();
    public static Data girlyTime = new Data();
    public static Data daringTime = new Data();
    public static Data schoolTime = new Data();
    public static List<Data> dataList = new List<Data>();

    #region Toggles
    //------------------- Toggles-------------------
    /// <summary>
    /// Sets the toggle info for every data and adds them to the <see cref="dataList"/> List
    /// </summary>
    /// <returns>The <see cref="dataList"/> List that contains all data</returns>
    public static void SetToggleBool()
    {
        // For Family Time
        // Sets the toggle's boolean to true
        familyTime.ToggleBool = true;
        // For Sexy Time
        // Sets the toggle's boolean to false
        sexyTime.ToggleBool = false;
        // For Macho Time
        // Sets the toggle's boolean to false
        machoTime.ToggleBool = false;
        // For Girly Time
        // Sets the toggle's boolean to false
        girlyTime.ToggleBool = false;
        // For Daring Time
        // Sets the toggle's boolean to false
        daringTime.ToggleBool = false;
        // For School Time
        // Sets the toggle's boolean to false
        schoolTime.ToggleBool = false;

    }
    #endregion

    #region Categories
    //------------------- Categories -------------------
    public static void SetCategories()
    {
        // For Family Time
        // Sets the category's name
        familyTime.Category = "family";
        // For Sexy Time
        // Sets the category's name
        sexyTime.Category = "sexy";
        // For Macho Time
        // Sets the category's name
        machoTime.Category = "macho";
        // For Girly Time
        // Sets the category's name
        girlyTime.Category = "girly";
        // For Daring Time
        // Sets the category's name
        daringTime.Category = "daring";
        // For School Time
        // Sets the category's name
        schoolTime.Category = "school";
    }
    #endregion

    #region CreateList
    /// <summary>
    /// Creates a List of type Data that contains all categories data.
    /// By default the language is set to English
    /// </summary>
    public static List<Data> CreateDataList()
    {
        SetCategories();
        SetToggleBool();
        // For Family Time

        // Adds the data to the list
        dataList.Add(familyTime);
        // For Sexy Time
        // Adds the data to the list
        dataList.Add(sexyTime);
        // For Macho Time
        // Adds the data to the list
        dataList.Add(machoTime);
        // For Girly Time
        // Adds the data to the list
        dataList.Add(girlyTime);
        // For Daring Time
        // Adds the data to the list
        dataList.Add(daringTime);
        // For School Time
        // Adds the data to the list
        dataList.Add(schoolTime);
        // Returns the now updated list
        return dataList;
    }
    #endregion

    #region Images
    //------------------- Images -------------------
    // Location for all card images for the light theme
    public static string locationLight = "cardGame/LightTheme/";
    // Location for all card images for the dark theme
    public static string locationDark = "cardGame/DarkTheme/";

    /// <summary>
    /// Gets the images for the light and the dark theme for the cards.
    /// </summary>
    /// <param name="dataList">The list that contains all the data.</param>
    /// <returns>The updated list with the data that contain the images for the light and the dark theme.</returns>
    public static List<Data> GetImages(List<Data> dataList)
    {
        // For each and every data in the dataList...
        foreach (var data in dataList)
        {
            // Adds the card image for the light theme of that category
            data.LightImage = Resources.Load<Sprite>(locationLight + data.Category);
            // Adds the card image for the dark theme of that category
            data.DarkImage = Resources.Load<Sprite>(locationDark + data.Category);
        }
        // Returns the now updated dataList
        return dataList;
    }
    #endregion

   
}
