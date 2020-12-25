using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SideMenu : MonoBehaviour
{
    public Images images;
    
    /// <summary>
    /// The side menu button.
    /// </summary>
    /// <param name="sideMenuButton">The side menu button</param>
    /// 
    public void SideMenuSettings()
    {
        // Get the hamburger sprite for light theme
        var hamburgerSpriteLight = Resources.Load<Sprite>(StringsAndConsants.cardGameLocationLight + StringsAndConsants.humburgerButtonName);
        // Get the back sprite for light theme
        var backSpriteLight = Resources.Load<Sprite>(StringsAndConsants.cardGameLocationLight + StringsAndConsants.arrowButtonName);
        // Get the hamburger sprite for dark theme
        var hamburgerSpriteDark = Resources.Load<Sprite>(StringsAndConsants.cardGameLocationDark + StringsAndConsants.humburgerButtonName);
        // Get the hamburger sprite for dark theme
        var backSpriteDark = Resources.Load<Sprite>(StringsAndConsants.cardGameLocationDark + StringsAndConsants.arrowButtonName);
        // Get the side menu gameObject
        var sideMenu = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("SideMenu"));
        // Get the side menu's blur
        var overlay = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("SideMenuBlur"));
        // Get the side menu's background
        var sideMenuBackground = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("SideMenuBackground"));
        // Get all the buttons in the scene 
        var buttons = Resources.FindObjectsOfTypeAll<Button>();
        // For each button in the scene...
        foreach (var sideMenuButton in buttons)
        {
            // If the button has the tag "SideMenuButton"...
            if (sideMenuButton.tag == "SideMenuButton")
            {
                // If the light theme is active...
                if (GlobalVariables.Theme == ThemeEnum.LightTheme)
                {
                    // If the image of the side menu's button is the hamburger...
                    if (sideMenuButton.image.sprite == hamburgerSpriteLight)
                    {
                        // Get the back sprite for light theme.
                        sideMenuButton.image.sprite = backSpriteLight;
                        // Slide in the side menu.
                        sideMenuBackground.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-146f, -104.18f), 0.25f);
                        // Set the overlay as active.
                        overlay.SetActive(true);
                    }
                    // Else the image of the side menu's button is the arrow...
                    else
                    {
                        // Get the hamburger sprite for light theme.
                        sideMenuButton.image.sprite = hamburgerSpriteLight;
                        // Slide out of the frame the side menu.
                        sideMenuBackground.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-700f, -104.18f), 0.25f);
                        // Seth the overlay as not active.
                        overlay.SetActive(false);
                    }
                }
                // Else the dark theme must be active...
                else
                {
                    // If the image of the side menu's button is the hamburger...
                    if (sideMenuButton.image.sprite == hamburgerSpriteDark)
                    {
                        // Get the back sprite for dark theme.
                        sideMenuButton.image.sprite = backSpriteDark;
                        // Slide in the side menu.
                        sideMenuBackground.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-146f, -104.18f), 0.25f);
                        // Set the overlay as active.
                        overlay.SetActive(true);

                    }
                    // Else...
                    else
                    {
                        // Get the hamburger sprite for dark theme.
                        sideMenuButton.image.sprite = hamburgerSpriteDark;
                        // Slide out of the frame the side menu.
                        sideMenuBackground.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-700f, -104.18f), 0.25f);
                        // Set the overlay as not active.
                        overlay.SetActive(false);
                    }
                }
            }
        }
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene(StringsAndConsants.mainMenuScene, LoadSceneMode.Single);
        GlobalVariables.fromSideMenu = true;
    }

    /// <summary>
    /// Method that opens instagram page when clicked on instagram button
    /// </summary>
    public void OpenInsagramPage()
    {
        Application.OpenURL("https://www.instagram.com/funtimesgame/?hl=el");
    }

    /// <summary>
    /// Method that opens facebook page when clicked on facebook button
    /// </summary>
    public void OpenFacebookPage()
    {
        Application.OpenURL("https://www.facebook.com/FunTimes-422796711170859");
    }

    /// <summary>
    /// Method that opens information about us when clicked on envelope button
    /// </summary>
    public void ContactUs()
    {
        Application.OpenURL("mailto:ceidtrash@gmail.com");
    }
/// <summary>
    /// Method that opens google form when clicked on button
    /// </summary>
    public void SuggestACard()
    {
        Application.OpenURL("https://docs.google.com/forms/u/0/d/e/1FAIpQLSfn4lIlUPgapdWPLXAFOxIT-bxBGmFutf_ZnU8K4_zZBZv2bg/formResponse");
    }
   
}
