using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Images : MonoBehaviour
{
    /// <summary>
    /// Change the image sprite of a button
    /// </summary>
    /// <param name="image">The image we want it to change to.</param>
    public void ChangeImage(Sprite image)
    {
        // Sets the buttons image equal to an image set in unity's inspector
        this.GetComponent<Button>().image.sprite = image;
    }

    public void Start()
    {
        // Create a temporary reference to the current scene.
        var currentScene = SceneManager.GetActiveScene();
        // Retrieve the name of this scene.
        var sceneName = currentScene.name;
        // If the choose decks scene is loaded...
        if (sceneName == StringsAndConsants.chooseDecksScene)
        {
            // Changes the "play" button.
            ChangeButtonImage(StringsAndConsants.decksLocationDark, StringsAndConsants.decksLocationLight, StringsAndConsants.playButtonTag, StringsAndConsants.playButtonName);
            // Changes the "main menu" button.
            ChangeButtonImage(StringsAndConsants.decksLocationDark, StringsAndConsants.decksLocationLight, StringsAndConsants.mainMenuButtonTag, StringsAndConsants.mainMenuButtonName);
        }
        // If the card game scene is loaded...
        else if (sceneName == StringsAndConsants.cardGameScene)
            // Changes the "next card" button.
            ChangeButtonImage(StringsAndConsants.cardGameLocationDark,StringsAndConsants.cardGameLocationLight,StringsAndConsants.nextButtonTag, StringsAndConsants.nextButtonName);
    }


    /// <summary>
    /// Sets the image of the next buttons according to the active theme and selected language.
    /// </summary>
    /// <param name="buttonName">The name with which the button is saved in resources.</param>
    /// <param name="tag">The name that is given as a tag inside Unity for the button.</param>
    public void ChangeButtonImage(string buttonLocationDark,string buttonLocationLight, string tag, string buttonName)
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
            if(button.tag == tag)
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
}
