using JetBrains.Annotations;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Images : MonoBehaviour
{
    /// <summary>
    /// Loads the button's and image's sprite's in a scene according to the active theme and language. 
    /// </summary>
    public void Start()
    {
        // Create a temporary reference to the current scene.
        var currentScene = SceneManager.GetActiveScene();
        // Retrieve the name of this scene.
        var sceneName = currentScene.name;
        // If the main menu scene is loaded...
        if (sceneName == StringsAndConsants.mainMenuScene)
        {
            // Changes the "play" button.
            ChangeButtonImage(StringsAndConsants.mainMenuLocationDark, StringsAndConsants.mainMenuLocationLight, StringsAndConsants.playButtonTag, StringsAndConsants.playButtonName);
            // Changes the "choose decks" button.
            ChangeButtonImage(StringsAndConsants.mainMenuLocationDark, StringsAndConsants.mainMenuLocationLight, StringsAndConsants.chooseDecksTag, StringsAndConsants.chooseDecksButtonName);
            // Changes the "back" button in settings.
            ChangeButtonImage(StringsAndConsants.mainMenuLocationDark, StringsAndConsants.mainMenuLocationLight, StringsAndConsants.backButtonTag, StringsAndConsants.backButtonName);
            // Changes the "side menu" button.
            ChangeImageByLanguage(StringsAndConsants.mainMenuLocationLight, StringsAndConsants.instructionsTag, StringsAndConsants.instructionsName);
        }
        // Else if the choose decks scene is loaded...
        else if (sceneName == StringsAndConsants.chooseDecksScene)
        {
            // Changes the "play" button.
            ChangeButtonImage(StringsAndConsants.decksLocationDark, StringsAndConsants.decksLocationLight, StringsAndConsants.playButtonTag, StringsAndConsants.playButtonName);
            // Changes the "main menu" button.
            ChangeButtonImage(StringsAndConsants.decksLocationDark, StringsAndConsants.decksLocationLight, StringsAndConsants.mainMenuButtonTag, StringsAndConsants.mainMenuButtonName);
        }
        // If the card game scene is loaded...
        else if (sceneName == StringsAndConsants.cardGameScene)
        {
            // Changes the "next card" button.
            ChangeButtonImage(StringsAndConsants.cardGameLocationDark, StringsAndConsants.cardGameLocationLight, StringsAndConsants.nextButtonTag, StringsAndConsants.nextButtonName);
            // Changes the "side menu" button.
            ChangeButtonImageByTheme(StringsAndConsants.cardGameLocationDark, StringsAndConsants.cardGameLocationLight, StringsAndConsants.sideMenuButtonTag, StringsAndConsants.humburgerButtonName);
        }
    }

    /// <summary>
    /// Changes the images of the main menu scene when the player clicks on a language button
    /// </summary>
    public void ChangeImageOnClick()
    {
        // Changes the "play" button.
        ChangeButtonImage(StringsAndConsants.mainMenuLocationDark, StringsAndConsants.mainMenuLocationLight, StringsAndConsants.playButtonTag, StringsAndConsants.playButtonName);
        // Changes the "choose decks" button.
        ChangeButtonImage(StringsAndConsants.mainMenuLocationDark, StringsAndConsants.mainMenuLocationLight, StringsAndConsants.chooseDecksTag, StringsAndConsants.chooseDecksButtonName);
        // Changes the "back" button in settings.
        ChangeButtonImage(StringsAndConsants.mainMenuLocationDark, StringsAndConsants.mainMenuLocationLight, StringsAndConsants.backButtonTag, StringsAndConsants.backButtonName);
        // Changes the instruction image.
        ChangeImageByLanguage(StringsAndConsants.mainMenuLocationLight, StringsAndConsants.instructionsTag, StringsAndConsants.instructionsName);
    }

    /// <summary>
    /// Changes an image's sprite according to the language
    /// </summary>
    /// <param name="path">The image's location in resources</param>
    /// <param name="tag">The image's tag in Unity</param>
    /// <param name="name">The image's name in resources</param>
    public void ChangeImageByLanguage(string path, string tag, string name)
    {
        // An array that contains all the buttons in the loaded scene.
        var images = Resources.FindObjectsOfTypeAll<Image>();
        // For each image in scene
        foreach (var image in images)
        {
            // If the images tag is equal to the tag...
            if (image.tag == tag)
            {
                // Sets the image's sprite for when English is on.
                image.sprite = Resources.Load<Sprite>(path + name + StringsAndConsants.EN);
                // If English is on...
                if (GlobalVariables.Language == LanguageEnum.English)
                    // Sets the image's sprite for when English is on.
                    image.sprite = Resources.Load<Sprite>(path + name + StringsAndConsants.EN);
                // If Greek is on...
                else if (GlobalVariables.Language == LanguageEnum.Greek)
                    // Sets the image's sprite for when Greek is on.
                    image.sprite = Resources.Load<Sprite>(path + name + StringsAndConsants.GR);
            }
        }        
    }

    /// <summary>
    /// Sets the image of the next buttons according to the active theme and selected language.
    /// </summary>
    /// <param name="buttonName">The name with which the button is saved in resources.</param>
    /// <param name="tag">The name that is given as a tag inside Unity for the button.</param>
    /// <param name="buttonLocationDark">The dark image's location in resources.</param>
    /// <param name="buttonLocationLight">The light image's location in resources.</param>
    public void ChangeButtonImage(string buttonLocationDark, string buttonLocationLight, string tag, string buttonName)
    {
        // An array that contains all the buttons in the loaded scene.
        var buttons = Resources.FindObjectsOfTypeAll<Button>();
        // A sprite for when Greek is on.
        Sprite buttonGR;
        // A sprite for when English is on.
        Sprite buttonEN;
        // For each button in buttons...
        foreach (var button in buttons)
        {
            // If the button;s tag is equal to the tag in parameters...
            if (button.tag == tag)
            {
                // If English is on...
                if (GlobalVariables.Language == LanguageEnum.English)
                {
                    // If the dark theme is active...
                    if (GlobalVariables.Theme == ThemeEnum.DarkTheme)
                        // Get the dark nextBtnEN image
                        buttonEN = Resources.Load<Sprite>(buttonLocationDark + buttonName + StringsAndConsants.EN);
                    // Else if the light theme is active...
                    else if (GlobalVariables.Theme == ThemeEnum.LightTheme)
                        // Get the dark nextBtnGR image
                        buttonEN = Resources.Load<Sprite>(buttonLocationLight + buttonName + StringsAndConsants.EN);
                    // Else...
                    else
                        // By default get the light nextBtnEN
                        buttonEN = Resources.Load<Sprite>(buttonLocationDark + buttonName + StringsAndConsants.EN);
                    // Sets the button's image to the English next card image
                    button.image.sprite = buttonEN;
                }
                // If Greek is on...
                else if (GlobalVariables.Language == LanguageEnum.Greek)
                {
                    // If the dark theme is active...
                    if (GlobalVariables.Theme == ThemeEnum.DarkTheme)
                        // Get the dark nextBtnGR image
                        buttonGR = Resources.Load<Sprite>(buttonLocationDark + buttonName + StringsAndConsants.GR);
                    // Else if the light theme is active...
                    else if (GlobalVariables.Theme == ThemeEnum.LightTheme)
                        // Get the light nextBtnGR
                        buttonGR = Resources.Load<Sprite>(buttonLocationLight + buttonName + StringsAndConsants.GR);
                    else
                        // By default get the light nextBtnGR
                        buttonGR = Resources.Load<Sprite>(buttonLocationLight + buttonName + StringsAndConsants.GR);
                    // Sets the button's image to the Greek next card image
                    button.image.sprite = buttonGR;
                }
                // Else...
                else
                {
                    // By default get the light nextBtnEN
                    buttonEN = Resources.Load<Sprite>(buttonLocationLight + buttonName + StringsAndConsants.EN);
                    // Sets the button's image to the English next card image
                    button.image.sprite = buttonEN;
                }
            }
        }
    }

    /// <summary>
    /// Sets the image of a button according to the active theme.
    /// </summary>
    /// <param name="buttonName">The name with which the button is saved in resources.</param>
    /// <param name="tag">The name that is given as a tag inside Unity for the button.</param>
    /// <param name="buttonLocationDark">The dark image's location in resources.</param>
    /// <param name="buttonLocationLight">The light image's location in resources.</param>
    public void ChangeButtonImageByTheme(string buttonLocationDark, string buttonLocationLight, string tag, string buttonName)
    {
        // An array that contains all the buttons in the loaded scene.
        var buttons = Resources.FindObjectsOfTypeAll<Button>();
        // Button sprite image
        Sprite buttonSprite;
        // For each button in buttons...
        foreach (var button in buttons)
        {
            // If the button's tag is equal to the tag in parameters...
            if (button.tag == tag)
            {
                // If the dark theme is active...
                if (GlobalVariables.Theme == ThemeEnum.DarkTheme)
                    // Get the dark nextBtnEN image
                    buttonSprite = Resources.Load<Sprite>(buttonLocationDark + buttonName);
                // Else if the light theme is active...
                else if (GlobalVariables.Theme == ThemeEnum.LightTheme)
                    // Get the dark nextBtnGR image
                    buttonSprite = Resources.Load<Sprite>(buttonLocationLight + buttonName);
                // Else...
                else
                    // By default get the light theme's version for the button's sprite
                    buttonSprite = Resources.Load<Sprite>(buttonLocationDark + buttonName);
                // Sets the button's sprite as the chosen button sprite
                button.image.sprite = buttonSprite;
            }
        }
    }

    /// <summary>
    /// Change the image sprite of a button
    /// </summary>
    /// <param name="image">The image we want it to change to.</param>
    public void ChangeImage(Sprite image)
    {
        // Sets the buttons image equal to an image set in unity's inspector
        this.GetComponent<Button>().image.sprite = image;
    }

}




