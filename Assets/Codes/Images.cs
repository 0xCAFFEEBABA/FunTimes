using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
}
