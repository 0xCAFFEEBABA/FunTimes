using System.Collections;
using System.Collections.Generic;
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

    // Sets the toggles active or not according to the bool that are stored in the "Global Variables" class...
    // So that when going back and forth in between scenes the values are kept the same.
    public void Start()
    {
        familyToggle.isOn = GlobalVariables.familyBool;
        sexyToggle.isOn = GlobalVariables.sexyBool;
        machoToggle.isOn = GlobalVariables.machoBool;
        girlyToggle.isOn = GlobalVariables.girlyBool;
        daringToggle.isOn = GlobalVariables.daringBool;
        schoolToggle.isOn = GlobalVariables.schoolBool;
    }


    // Checks the value of every toggle and stores it to the "Global Variables" class.
    public void OnDestroy()
    {
        GlobalVariables.familyBool = familyToggle.isOn;
        GlobalVariables.sexyBool = sexyToggle.isOn;
        GlobalVariables.machoBool = machoToggle.isOn;
        GlobalVariables.girlyBool = girlyToggle.isOn;
        GlobalVariables.daringBool = daringToggle.isOn;
        GlobalVariables.schoolBool = schoolToggle.isOn;
    }
}
