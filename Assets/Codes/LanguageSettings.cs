using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LanguageSettings : MonoBehaviour
{

    public void ChangeImage(Sprite image)
    {
        this.GetComponent<Button>().image.sprite = image;
    }

}
