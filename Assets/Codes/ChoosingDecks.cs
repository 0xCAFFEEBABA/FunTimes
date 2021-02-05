using Newtonsoft.Json.Linq;

using System.Linq;

using TMPro;

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
        GlobalVariables.GetPreviews();
        GlobalVariables.OpenJsonCardsFiles();

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
        AccessPreviewData();
        FindToggles();
        
        // Add the toggles and the categories name in the dictionary
        GlobalVariables.PreviewsDictionary.Add("family", new ToggleBool() { Toggle = familyToggle, PreviewBool = true });
        GlobalVariables.PreviewsDictionary.Add("sexy", new ToggleBool() { Toggle = sexyToggle });
        GlobalVariables.PreviewsDictionary.Add("macho", new ToggleBool() { Toggle = machoToggle });
        GlobalVariables.PreviewsDictionary.Add("girly", new ToggleBool() { Toggle = girlyToggle });
        GlobalVariables.PreviewsDictionary.Add("daring", new ToggleBool() { Toggle = daringToggle });
        GlobalVariables.PreviewsDictionary.Add("school", new ToggleBool() { Toggle = schoolToggle });
    }

    public void AccessPreviewData()
    {
        var filePath = $"Json/previews";
        var previewsJData = GlobalVariables.AccessFileData(filePath);
        // Creates an array that contains the elements of the JSON file's array.
        var previewsJArray = (JArray)previewsJData["previews"];
        // For each and every object inside the "cards[]" array...
        foreach (JObject content in previewsJArray.Children<JObject>())
        { 
            // For each and every data in the list of data...
            foreach (var data in GlobalVariables.dataList)
            {
                var categoryPreviewDataList = content.Properties().ToList();

                if(categoryPreviewDataList[0].Value.ToString() == data.Category.ToString())
                {
                    data.PreviewCard.PreviewGR = categoryPreviewDataList[1].Value.ToString();
                    data.PreviewCard.PreviewEN = categoryPreviewDataList[2].Value.ToString();
                }
            }
        }
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
        // Gets the overlay
        var overlay = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("Overlay"));
        overlay.SetActive(true);

        foreach (var data in GlobalVariables.dataList)
        {
            if (data.Category.ToString() == categoryTag)
            {
                // Gets the close button
                var closeButton = previewCard.transform.GetChild(0);
                // Sets the close button's image as the image in resources that has the name "categoryX"
                closeButton.GetComponent<Button>().image.sprite = data.PreviewCard.CloseButtonImage;
                closeButton.tag = deckTag;

                // Gets the deck cards preview image
                var deckPreviewImage = previewCard.transform.GetChild(1);
                // Sets the deck cards preview image as the image in resources that has the name "category"
                deckPreviewImage.GetComponent<Image>().sprite = data.PreviewCard.DeckPreviewImage;

                // Gets the deck cards preview text GUI element
                var deckPreviewText = previewCard.transform.GetChild(2);

                // Gets the ads button
                var adsButton = previewCard.transform.GetChild(3);
                // Gets the ads button text
                var adsButtonText = adsButton.GetChild(1);

                // Gets the toggle inside a category's preview
                var categoryToggle = previewCard.transform.GetChild(4);
                categoryToggle.tag = "SideMenu";
                // Gets the toggle's background
                var toggleBackground = categoryToggle.transform.GetChild(0);
                //Gets the background's check mark
                var toggleCheckmark = toggleBackground.transform.GetChild(0);
                // Sets the check mark's image as the image in resources that has the name "categoryAfter"
                toggleCheckmark.GetComponent<Image>().sprite = data.PreviewCard.ToggleCheckMarkImage;
                // Sets the check mark inactive
                categoryToggle.GetComponent<Toggle>().isOn = false;

                // Gets the unlocked cards text GUI element
                var numberOfUnlockedCardsText = previewCard.transform.GetChild(5);
                
                // Gets the buy complete deck button
                var buyAllButton = previewCard.transform.GetChild(6);
                // Sets the button's image as the image that is in the resources as "categoryBuy"
                buyAllButton.GetComponent<Button>().image.sprite = data.PreviewCard.BuyAllButtonImage;
                var buyAllText = buyAllButton.GetChild(0);

                if (GlobalVariables.Language == LanguageEnum.English)
                {
                    deckPreviewText.GetComponent<TextMeshProUGUI>().text = $"{data.Length}{data.PreviewCard.PreviewEN}";
                    numberOfUnlockedCardsText.GetComponent<TextMeshProUGUI>().text = $"unlocked ";
                    adsButtonText.GetComponent<TextMeshProUGUI>().text = $"unlock 5";
                    buyAllText.GetComponent<TextMeshProUGUI>().text = "buy all";
                }
                else if (GlobalVariables.Language == LanguageEnum.Greek)
                {
                    deckPreviewText.GetComponent<TextMeshProUGUI>().text = $"{data.Length}{data.PreviewCard.PreviewGR}";
                    numberOfUnlockedCardsText.GetComponent<TextMeshProUGUI>().text = $"ξεκλειδωμένες ";
                    adsButtonText.GetComponent<TextMeshProUGUI>().text = $"ξεκλείδωσε 5";
                    buyAllText.GetComponent<TextMeshProUGUI>().text = "παρ\'τες όλες";
                }

            }
        }
        
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
        // For each data in the list...
        foreach(var data in GlobalVariables.dataList)
        {
            // For each category and toggle pair...
            foreach (var categoryAndTogglePair in GlobalVariables.PreviewsDictionary)
            {
                // If the category is NOT locked... 
                if (data.IsLocked == false && data.Category.ToString() == categoryAndTogglePair.Key)
                {
                    // Gets the toggle's is On value
                    data.ToggleBool = categoryAndTogglePair.Value.Toggle.isOn;
                }
                // If the category IS locked...
                if (data.IsLocked == true && data.Category.ToString() == categoryAndTogglePair.Key)
                {
                    // Gets the preview's toggle is On valuje
                    data.ToggleBool = categoryAndTogglePair.Value.PreviewBool;
                }
            }
                
        }
    }

}
