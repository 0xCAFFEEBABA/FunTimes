using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;


public class SideMenu : MonoBehaviour
{
    /// <summary>
    /// The side menu button.
    /// </summary>
    /// <param name="sideMenuButton">The side menu button</param>
    /// 
    public void SideMenuSettings(Button sideMenuButton)
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

        // If the light theme is active...
        if (GlobalVariables.Theme == ThemeEnum.LightTheme)
        {
            // If the image of the side menu's button is the hamburger...
            if (sideMenuButton.image.sprite == hamburgerSpriteLight)
            {
                // Get the back sprite for light theme.
                sideMenuButton.image.sprite = backSpriteLight;
                // Sets the side menu component as active
                sideMenu.SetActive(true);
            }
            // Else the image of the side menu's button is the arrow...
            else
            {
                // Get the hamburger sprite for light theme.
                sideMenuButton.image.sprite = hamburgerSpriteLight;
                // Sets the side menu component as not active
                sideMenu.SetActive(false);
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
                // Sets the side menu component as active
                sideMenu.SetActive(true);
            }
            // Else...
            else
            {
                // Get the hamburger sprite for dark theme.
                sideMenuButton.image.sprite = hamburgerSpriteDark;
                // Sets the side menu component as not active
                sideMenu.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Navigates to the settings menu
    /// </summary>
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
    /// Opens a Google form created specifically for players to give card suggestions
    /// </summary>
    public void SendSuggestion()
    {
        // If the game is in English...
        if (GlobalVariables.Language == LanguageEnum.English)
            // Go to the English Google Form
            Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSfn4lIlUPgapdWPLXAFOxIT-bxBGmFutf_ZnU8K4_zZBZv2bg/viewform?fbclid=IwAR0eegZzbe42oeAyZpYA5XMbzH7XYMBWgw8Qp4yxdgWO1CK0S1ukNMJSwGoδ");
        // Else
        else
            // Go to the Greek Google Form
            Application.OpenURL("https://docs.google.com/forms/d/1Xt3Lu4pHlHbrsN3jCd_nS-pnMoNa0K_UtJRMjAjt4mg/edit");
    }
}
