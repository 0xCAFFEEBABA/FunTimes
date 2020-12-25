using System.Linq;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Contains methods for the choose decks scene
/// </summary>
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
        var toggles = Resources.FindObjectsOfTypeAll<Toggle>();

        foreach (var data in GlobalVariables.dataList)
        {
            foreach(var toggle in toggles)
            {
                // Gets the lock button's tag
                var deckTag = toggle.tag;
                // Sets the tag as the luck button's minus the "Card"
                var categoryTag = deckTag.Substring(0, deckTag.Length - 4);

                if (data.Category.ToString() == categoryTag)
                {
                    if(data.IsLocked == false)
                    {
                        toggle.transform.gameObject.SetActive(true);

                        toggle.transform.parent.GetChild(2).gameObject.SetActive(false);
                    }
                    else
                    {
                        toggle.transform.gameObject.SetActive(false);

                        toggle.transform.parent.GetChild(2).gameObject.SetActive(true);
                    }
                }
            }
        }

        FindToggles();
        
        // Add the toggles and the categories name in the dictionary
        GlobalVariables.PreviewsDictionary.Add("family", new ToggleBool() { Toggle = familyToggle, PreviewBool = true });
        GlobalVariables.PreviewsDictionary.Add("sexy", new ToggleBool() { Toggle = sexyToggle });
        GlobalVariables.PreviewsDictionary.Add("macho", new ToggleBool() { Toggle = machoToggle });
        GlobalVariables.PreviewsDictionary.Add("girly", new ToggleBool() { Toggle = girlyToggle });
        GlobalVariables.PreviewsDictionary.Add("daring", new ToggleBool() { Toggle = daringToggle });
        GlobalVariables.PreviewsDictionary.Add("school", new ToggleBool() { Toggle = schoolToggle });
    }

    /// <summary>
    /// Finds the active toggles in scene and sets their values equal to every <see cref="GlobalVariables.dataList"/>
    /// data's toggle boolean 
    /// </summary>
    public void FindToggles()
    {
        // Finds family toggle and checks if it's on
        var gameObject = GameObject.Find(StringsAndConsants.familyToggleName);
        if (gameObject != null)
        {
            familyToggle = gameObject.GetComponent<Toggle>();
            familyToggle.isOn = GlobalVariables.familyTime.ToggleBool;
        }
        

        // Finds sexy toggle and checks if it's on
        gameObject = GameObject.Find(StringsAndConsants.sexyToggleName);
        if (gameObject != null)
        {
            sexyToggle = gameObject.GetComponent<Toggle>();
            sexyToggle.isOn = GlobalVariables.sexyTime.ToggleBool;
        }

        // Finds macho toggle and checks if it's on
        gameObject = GameObject.Find(StringsAndConsants.machoToggleName);
        if (gameObject != null)
        {
            machoToggle = gameObject.GetComponent<Toggle>();
            machoToggle.isOn = GlobalVariables.machoTime.ToggleBool;
        }

        // Finds girly toggle and checks if it's on
        gameObject = GameObject.Find(StringsAndConsants.girlyToggleName);
        if (gameObject != null)
        {
            girlyToggle = gameObject.GetComponent<Toggle>();
            girlyToggle.isOn = GlobalVariables.girlyTime.ToggleBool;
        }

        // Finds daring toggle and checks if it's on
        gameObject = GameObject.Find(StringsAndConsants.daringToggleName);
        if (gameObject != null)
        {
            daringToggle = gameObject.GetComponent<Toggle>();
            daringToggle.isOn = GlobalVariables.daringTime.ToggleBool;
        }
        
        // Finds school toggle and checks if it's on
        gameObject = GameObject.Find(StringsAndConsants.schoolToggleName);
        if (gameObject != null)
        {
            schoolToggle = gameObject.GetComponent<Toggle>();
            schoolToggle.isOn = GlobalVariables.schoolTime.ToggleBool;
        }
    }

    /// <summary>
    /// Create the preview card according to the lock of the category clicked
    /// </summary>
    /// <param name="lockButton"></param>
    public void CreatePreview(Button lockButton)
    {
        // Gets the lock button's tag
        var deckTag = lockButton.tag;
        // Sets the tag as the luck button's minus the "Card"
        var categoryTag = deckTag.Substring(0, deckTag.Length - 4);
        
        // Gets the preview card
        var previewCard = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("PreviewCard"));
        
        // Gets the close button
        var closeButton = previewCard.transform.GetChild(0);
        // Sets the close button's image as the image in resources that has the name "categoryX"
        closeButton.GetComponent<Button>().image.sprite = Resources.Load<Sprite>(StringsAndConsants.previewsLocation + categoryTag + "X");
        closeButton.tag = deckTag;

        // Gets the deck cards preview image
        var deckPreviewImage = previewCard.transform.GetChild(1);
        // Sets the deck cards preview image as the image in resources that has the name "category"
        deckPreviewImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(StringsAndConsants.previewsLocation + categoryTag);

        // Gets the toggle inside a category's preview
        var categoryToggle = previewCard.transform.GetChild(4);
        categoryToggle.tag = "SideMenu";
        // Gets the toggle's background
        var toggleBackground = categoryToggle.transform.GetChild(0); 
        //Gets the background's check mark
        var toggleCheckmark = toggleBackground.transform.GetChild(0);
        // Sets the check mark's image as the image in resources that has the name "categoryAfter"
        toggleCheckmark.GetComponent<Image>().sprite = Resources.Load<Sprite>(StringsAndConsants.previewsLocation + categoryTag + "After");
        // Sets the check mark inactive
        categoryToggle.GetComponent<Toggle>().isOn = false;

        // Gets the buy complete deck button
        var buyAllButton = previewCard.transform.GetChild(6);
        // Sets the button's image as the image that is in the resources as "categoryBuy"
        buyAllButton.GetComponent<Button>().image.sprite = Resources.Load<Sprite>(StringsAndConsants.previewsLocation + categoryTag + "Buy");

        previewCard.SetActive(true);
    }

    public void GetToggleValueOnClick(Button closeButton)
    {
        var previewCard = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("PreviewCard"));

        // Gets the close button's tag
        var deckTag = closeButton.tag;
        // Sets the tag as the luck button's minus the "Card"
        var category = deckTag.Substring(0, deckTag.Length - 4);

        foreach(var categoryAndTogglePair in GlobalVariables.PreviewsDictionary)
        {
            if (categoryAndTogglePair.Key == category)
            {
                // Finds family toggle and checks if it's on
                var previewToggle = Resources.FindObjectsOfTypeAll<Toggle>().FirstOrDefault(g => g.CompareTag("SideMenu"));
                if (previewToggle != null)
                {
                   categoryAndTogglePair.Value.PreviewBool = previewToggle.isOn;
                }
            }
        }
    }

    public void SetPeviewToggleOnClick(Button lockButton)
    {
        var previewCard = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("PreviewCard"));

        // Gets the close button's tag
        var deckTag = lockButton.tag;
        // Sets the tag as the luck button's minus the "Card"
        var category = deckTag.Substring(0, deckTag.Length - 4);

        foreach (var categoryAndTogglePair in GlobalVariables.PreviewsDictionary)
        {
            if (categoryAndTogglePair.Key == category)
            {
                // Finds family toggle and checks if it's on
                var previewToggle = Resources.FindObjectsOfTypeAll<Toggle>().FirstOrDefault(g => g.CompareTag("SideMenu"));
                if (previewToggle != null)
                {
                    previewToggle.isOn = categoryAndTogglePair.Value.PreviewBool;
                }
            }
        }
    }

    /// <summary>
    /// Checks the value of every toggle and stores it to the "Global Variables" class.
    ///  Calls the OpenFiles method before the scene is destroyed
    /// </summary>
    public void OnDestroy()
    {
        //// Sets each toggle's boolean in the global variables class equal to the toggle's booleans in the scene
        //GlobalVariables.familyTime.ToggleBool = familyToggle.isOn;
        //GlobalVariables.sexyTime.ToggleBool = sexyToggle.isOn;
        //GlobalVariables.machoTime.ToggleBool = machoToggle.isOn;
        //GlobalVariables.girlyTime.ToggleBool = girlyToggle.isOn;
        //GlobalVariables.daringTime.ToggleBool = daringToggle.isOn;
        //GlobalVariables.schoolTime.ToggleBool = schoolToggle.isOn;

        foreach(var data in GlobalVariables.dataList)
        {
            foreach (var categoryAndTogglePair in GlobalVariables.PreviewsDictionary)
            {
                if (data.IsLocked == false && data.Category.ToString() == categoryAndTogglePair.Key)
                {
                    data.ToggleBool = categoryAndTogglePair.Value.Toggle.isOn;
                }

                if (data.IsLocked == true && data.Category.ToString() == categoryAndTogglePair.Key)
                {
                    data.ToggleBool = categoryAndTogglePair.Value.PreviewBool;
                }
            }
                
        }
    }

}
