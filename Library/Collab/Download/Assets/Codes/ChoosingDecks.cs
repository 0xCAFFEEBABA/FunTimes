using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json.Linq;

public class ChoosingDecks : MonoBehaviour
{
    // Variables that we connect to the actual game objects in unity.
    public Toggle familyToggle;
    public Toggle sexyToggle;
    public Toggle machoToggle;
    public Toggle girlyToggle;
    public Toggle daringToggle;
    public Toggle schoolToggle;

    private string jsonString;
    private JObject fileData;

    /// <summary>
    /// Sets the toggles active or not according to the bool that are stored in the "Global Variables" class...
    /// So that when going back and forth in between scenes the values are kept the same.
    /// </summary>
    public void Start()
    {
        GlobalVariables.CreateDataList();

        familyToggle.isOn = GlobalVariables.familyTime.ToggleBool;
        sexyToggle.isOn = GlobalVariables.sexyTime.ToggleBool;
        machoToggle.isOn = GlobalVariables.machoTime.ToggleBool;
        girlyToggle.isOn = GlobalVariables.girlyTime.ToggleBool;
        daringToggle.isOn = GlobalVariables.daringTime.ToggleBool;
        schoolToggle.isOn = GlobalVariables.schoolTime.ToggleBool;
        
    }

    /// <summary>
    /// Checks the value of every toggle and stores it to the "Global Variables" class.
    ///  Calls the OpenFiles method before the scene is destroyed
    /// </summary>
    public void OnDestroy()
    {
        GlobalVariables.familyTime.ToggleBool = familyToggle.isOn;
        GlobalVariables.sexyTime.ToggleBool = sexyToggle.isOn;
        GlobalVariables.machoTime.ToggleBool = machoToggle.isOn;
        GlobalVariables.girlyTime.ToggleBool = girlyToggle.isOn;
        GlobalVariables.daringTime.ToggleBool = daringToggle.isOn;
        GlobalVariables.schoolTime.ToggleBool = schoolToggle.isOn;
        OpenJsonFiles();
    }

    /// <summary>
    /// Opens and reads an entire JSON file and parses it accordingly.
    /// In our case to a list of data.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public JObject AccessFileData(string filePath)
    {
        // Sets the string equal to all the contents of the file
        jsonString = File.ReadAllText(Application.dataPath + filePath);
        // Sets fileData equal to the according json format of the string
        fileData = JObject.Parse(jsonString);
        // Returns the Json data
        return fileData;
    }
    /// <summary>
    /// Unlocks the appropriate JSON files when the according toggle is on.
    /// </summary>
    public void OpenJsonFiles()
    {
        // For each and every data in the dataList...
        foreach (var data in GlobalVariables.dataList)
        {
            string language;
            string filePath;
            // For language
            // If the data's language is English...
            if (data.Language == LanguageEnum.English)
                // Sets the string to EN
                language = "EN";
            // Else if the data's language is Greek...
            else if (data.Language == LanguageEnum.Greek)
                // Sets the string to GR
                language = "GR";
            // Else...
            else
                // By default language is EN
                language = "EN";
            // For the JsonData
            // If the toggle is active...
            if (data.ToggleBool == true)
            {
                // Sets the file path accordingly in order to access that specific file
                filePath = $"/Codes/Json/{data.Category}Time{language}.json";
                // Sets the data's JsonData to the data in the accessed json file
                data.JsonData = AccessFileData(filePath);
                // Creates an array that contains the elements of the JSON file's array.
                JArray cards = (JArray)data.JsonData["cards"];
                // Sets data's length equal the size of the array.
                data.Length = cards.Count;
            }
        }
    }
}
