using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LanguageSettings : MonoBehaviour
{
    // Change the image sprite of a button
    // Mainly for mainMenu scene
    public void ChangeImage(Sprite image)
    {
        this.GetComponent<Button>().image.sprite = image;
    }


}
