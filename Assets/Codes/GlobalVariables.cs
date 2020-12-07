using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class GlobalVariables
{
    #region Variables
    /// <summary>
    /// The game's theme
    /// </summary>
    public static ThemeEnum Theme;
    /// <summary>
    /// The game's language
    /// </summary>
    public static LanguageEnum Language = LanguageEnum.None;
    /// <summary>
    /// A Data type variable
    /// </summary>
    public static Data familyTime = new Data();
    /// <summary>
    /// A Data type variable
    /// </summary>
    public static Data sexyTime = new Data();
    /// <summary>
    /// A Data type variable
    /// </summary>
    public static Data machoTime = new Data();
    /// <summary>
    /// A Data type variable
    /// </summary>
    public static Data girlyTime = new Data();
    /// <summary>
    /// A Data type variable
    /// </summary>
    public static Data daringTime = new Data();
    /// <summary>
    /// A Data type variable
    /// </summary>
    public static Data schoolTime = new Data();
    /// <summary>
    /// A list with all Data 
    /// </summary>
    public static List<Data> dataList = new List<Data>();
    /// <summary>
    /// A dictionary with key = Data and value = Pool from ObjectPooler class
    /// It matches {category}Pool <see cref="Pool"/> to {category}Time <see cref="Data"/> 
    /// </summary>
    public static Dictionary<Data, ObjectPooler.Pool> dataAndPools = new Dictionary<Data, ObjectPooler.Pool>();
    /// <summary>
    /// A dictionary that contains a Queue for each category
    /// </summary>
    public static Dictionary<CategoryEnum, Queue<GameObject>> poolDictionary = new Dictionary<CategoryEnum, Queue<GameObject>>();
    /// <summary>
    /// Checks if the player pressed to move to another scene from Side Menu in "cardGame" scene
    /// </summary>
    public static bool fromSideMenu = false;
    #endregion

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
        familyTime.Category = CategoryEnum.family;
        // For Sexy Time
        // Sets the category's name
        sexyTime.Category = CategoryEnum.sexy;
        // For Macho Time
        // Sets the category's name
        machoTime.Category = CategoryEnum.macho;
        // For Girly Time
        // Sets the category's name
        girlyTime.Category = CategoryEnum.girly;
        // For Daring Time
        // Sets the category's name
        daringTime.Category = CategoryEnum.daring;
        // For School Time
        // Sets the category's name
        schoolTime.Category = CategoryEnum.school;
    }
    #endregion

    #region CreateList
    /// <summary>
    /// Creates a List of type Data that contains all categories data.
    /// By default the language is set to English
    /// </summary>
    public static List<Data> CreateDataList()
    {
        // If the dataList is empty... 
        if (dataList.Count == 0)
        {
            // Sets the default values for the categories.
            SetCategories();
            // Sets the default values for the toggles
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
        }
        // Returns the now updated list
        return dataList;
    }
    #endregion

    #region Images
    //------------------- Images -------------------
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
            data.LightImage = Resources.Load<Sprite>(StringsAndConsants.cardGameLocationLight + data.Category);
            // Adds the card image for the dark theme of that category
            data.DarkImage = Resources.Load<Sprite>(StringsAndConsants.cardGameLocationDark + data.Category);
        }
        // Returns the now updated dataList
        return dataList;
    }
    #endregion

    #region JSON
    /// <summary>
    /// The entire JSON file as a string.
    /// </summary>
    private static string jsonString;
    /// <summary>
    /// The JObject form of the JSON file.
    /// </summary>
    private static JObject fileData;

    /// <summary>
    /// Opens and reads an entire JSON file and parses it accordingly.
    /// In our case to a list of data.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static JObject AccessFileData(string filePath)
    {
        // Sets the string equal to all the contents of the file
        // jsonString = File.ReadAllText(Application.dataPath + filePath);
        var text = Resources.Load<TextAsset>(filePath);
        jsonString = text.ToString();
        // Sets fileData equal to the according json format of the string
        fileData = JObject.Parse(jsonString);
        // Returns the Json data
        return fileData;
    }
    /// <summary>
    /// Unlocks the appropriate JSON files when the according toggle is on.
    /// </summary>
    public static void OpenJsonFiles()
    {
        // For each and every data in the dataList...
        foreach (var data in GlobalVariables.dataList)
        {
            string filePath;
            // For language
            data.Language = Language;
            
            // For the JsonData
            // If the toggle is active...
            if (data.ToggleBool == true)
            {
                // Sets the file path accordingly in order to access that specific file
                //filePath = $"/Codes/Json/{data.Category}Time{data.Language}.json";
                filePath = $"Json/{data.Category}Time{data.Language}";

                // Sets the data's JsonData to the data in the accessed json file
                data.JsonData = AccessFileData(filePath);
                // Creates an array that contains the elements of the JSON file's array.
                JArray cards = (JArray)data.JsonData[StringsAndConsants.cards];
                // Sets data's length equal the size of the array.
                data.Length = cards.Count;
            }
        }
    }
    #endregion
}
