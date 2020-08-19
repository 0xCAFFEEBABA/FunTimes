using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Threading.Tasks;
using UnityEngine.UI;

public class JsonParse : MonoBehaviour
{
    private string jsonString;
    private JsonData fileData;

    // Opens and reads an entire JSON file and parses it accordingly.
    // In our case to a list of data.
    public JsonData AccessFileData(string filePath)
    {
        jsonString = File.ReadAllText(Application.dataPath + filePath);
        fileData = JsonMapper.ToObject(jsonString);
        return fileData;
    }

    public void Start()
    {
        //string filePath = "/Codes/Json/familyTimeEN.json";
        //var data = AccessFileData("/Codes/Json/familyTimeEN.json");
        //Debug.Log(data["cards"][1]["task"]);
        OpenJsonFiles();
    }

    // Unlocks the appropriate JSON files when the according toggle is on.
    public void OpenJsonFiles()
    {
        string language;
        // Checks which language is active and by default sets the English language
        if (GlobalVariables.isEnglish == true)
            language = "EN";
        else if (GlobalVariables.isGreek == true)
            language = "GR";
        else
            language = "EN";
        string filePath;
        // If the family toggle is active...
        if (GlobalVariables.familyBool == true)
        {
            filePath = $"/Codes/Json/familyTime{language}.json";
            GlobalVariables.familyData = AccessFileData(filePath);
        }
        // If the sexy toggle is active...
        if (GlobalVariables.sexyBool == true)
        {
            filePath = $"/Codes/Json/sexyTime{language}.json";
            GlobalVariables.sexyData = AccessFileData(filePath);
        }
        // If the macho toggle is active...
        if (GlobalVariables.machoBool == true)
        {
            filePath = $"/Codes/Json/machoTime{language}.json";
            GlobalVariables.machoData = AccessFileData(filePath);
        }
        // If the girly toggle is active...
        if (GlobalVariables.girlyBool == true)
        {
            filePath = $"/Codes/Json/girlyTime{language}.json";
            GlobalVariables.girlyData = AccessFileData(filePath);
        }
        // If the daring toggle is active...
        if (GlobalVariables.daringBool == true)
        {
            filePath = $"/Codes/Json/daringTime{language}.json";
            GlobalVariables.daringData = AccessFileData(filePath);
        }
        // If the school toggle is active...
        if (GlobalVariables.schoolBool == true)
        {
            filePath = $"/Codes/Json/schoolTime{language}.json";
            GlobalVariables.schoolData = AccessFileData(filePath);
        }
    }
}
