using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Threading.Tasks;

public class JsonParse : MonoBehaviour
{
    private string jsonString;
    private JsonData itemData;
    void Start()
    {
        jsonString = File.ReadAllText(Application.dataPath + "/Codes/Json/familyTimeEN.json");
        itemData = JsonMapper.ToObject(jsonString);
        Debug.Log(itemData["cards"][1]["task"]);
    }

}
