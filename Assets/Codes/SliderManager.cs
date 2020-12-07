using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    float musicVolume = 1f;
    private AudioSource[] sources;

    /// <summary>
    /// Controls and updates the new volume from the slider
    /// </summary>
    /// <param name="newVolume"></param>
    public void ChangeSlider(float newVolume)
    {
        musicVolume = newVolume;
        PlayerPrefs.SetFloat("SliderVolume", musicVolume);
        UpdateVolumes();
    }

    /// <summary>
    /// Calls the <see cref="UpdateVolumes"/> method to update the volume at the start of every scene
    /// </summary>
    public void Start()
    {
        UpdateVolumes();
    }
   
    /// <summary>
    /// Updates the volume for every audio source in scene
    /// </summary>
    public void UpdateVolumes()
    {
        // Gets all the audio objects in current scene
        sources = FindObjectsOfType<AudioSource>();
        // For each audio source in scene...
        foreach (var source in sources)
        {
            // Set the volume equal to the slider's volume
            source.volume = PlayerPrefs.GetFloat("SliderVolume");
        }
    }


}
