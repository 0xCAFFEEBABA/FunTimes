using UnityEngine;
using UnityEngine.UI;


public class ChoosingDecks : MonoBehaviour
{
    // Variables that we connect to the actual game objects in unity.
    public Toggle familyToggle;
    public Toggle sexyToggle;
    public Toggle machoToggle;
    public Toggle girlyToggle;
    public Toggle daringToggle;
    public Toggle schoolToggle;


    /// <summary>
    /// Sets the toggles active or not according to the bool that are stored in the "Global Variables" class...
    /// So that when going back and forth in between scenes the values are kept the same.
    /// </summary>
    public void Start()
    {
        var gameObject = GameObject.Find("FamilyTimeToggle");
        familyToggle = gameObject.GetComponent<Toggle>();
        familyToggle.isOn = GlobalVariables.familyTime.ToggleBool;

        gameObject = GameObject.Find("SexyTimeToggle");
        sexyToggle = gameObject.GetComponent<Toggle>();
        sexyToggle.isOn = GlobalVariables.sexyTime.ToggleBool;

        gameObject = GameObject.Find("MachoTimeToggle");
        machoToggle = gameObject.GetComponent<Toggle>();
        machoToggle.isOn = GlobalVariables.machoTime.ToggleBool;

        gameObject = GameObject.Find("GirlyTimeToggle");
        girlyToggle = gameObject.GetComponent<Toggle>();
        girlyToggle.isOn = GlobalVariables.girlyTime.ToggleBool;

        gameObject = GameObject.Find("DaringTimeToggle");
        daringToggle = gameObject.GetComponent<Toggle>();
        daringToggle.isOn = GlobalVariables.daringTime.ToggleBool;

        gameObject = GameObject.Find("SchoolTimeToggle");
        schoolToggle = gameObject.GetComponent<Toggle>();
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
    }

}
