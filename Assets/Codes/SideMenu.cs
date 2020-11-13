using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideMenu : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sideMenuButton">The side menu button</param>
    public void SideMenuSettings(Button sideMenuButton)
    {
        //
        var hamburgerSpriteLight = Resources.Load<Sprite>(StringsAndConsants.cardGameLocationLight + StringsAndConsants.backArrow);
        //
        var backSpriteLight = Resources.Load<Sprite>(StringsAndConsants.cardGameLocationLight + StringsAndConsants.humburger);
        //
        var hamburgerSpriteDark = Resources.Load<Sprite>(StringsAndConsants.cardGameLocationDark + StringsAndConsants.backArrow);
        //
        var backSpriteDark = Resources.Load<Sprite>(StringsAndConsants.cardGameLocationDark + StringsAndConsants.humburger);

        // If the light theme is active...
        if (GlobalVariables.Theme == ThemeEnum.LightTheme)
        {
            // If the image of the side menu's button is the hamburger...
            if (sideMenuButton.image.sprite == hamburgerSpriteLight)
            {
                //
                sideMenuButton.image.sprite = backSpriteLight;
                // Sets the side menu component as active
            }
            // Else the image of the side menu's button is the arrow...
            else
            {
                //
                sideMenuButton.image.sprite = hamburgerSpriteLight;
                // Sets the side menu component as not active
            }

        }
        // Else the dark theme must be active...
        else
        {
            //
            if (sideMenuButton.image.sprite == hamburgerSpriteDark)
            {
                //
                sideMenuButton.image.sprite = backSpriteDark;
            }
            //
            else
            {
                //
                sideMenuButton.image.sprite = hamburgerSpriteDark;
            }
        }

    }

    ///
    public void OpenUrl()
    {
        Application.OpenURL("https://www.google.com/search?q=happy+cat&sxsrf=ALeKk02aKbrYnfOf0vdMXumnCHdKWbIokg:1604909220410&source=lnms&tbm=isch&sa=X&ved=2ahUKEwjDr-rfgPXsAhXUasAKHco4DC4Q_AUoAXoECAUQAw&biw=1536&bih=722");
    }

    /// <summary>
    /// 
    /// </summary>
    public void OpenInsagramPage()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public void OpenFacebookPage()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public void ContactUs()
    {

    }
}
