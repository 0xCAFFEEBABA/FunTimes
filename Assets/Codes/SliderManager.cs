using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    // Make an array for sliders
    private Slider[] sliders;
    // Initialize musicVolume to 1f.
    float musicVolume = 1f;
    // Make an array for audiosources
    private AudioSource[] sources;
  
     // To control slider.
    public void ChangeSlider(float newVolume)
    {
        // Set music volume equal to newVolume.
        musicVolume = newVolume;
        // Save musicVolume in PlayerPref's SliderVolume.
        PlayerPrefs.SetFloat("SliderVolume", musicVolume);
       
    }

    
    void Update()
    {
        // Find all audiosources in current scene.
        sources = FindObjectsOfType<AudioSource>();
        // Find all sliders in current scene.
        sliders = FindObjectsOfType<Slider>();

        // Foreach source in sources set their volume equal to SliderVolume
        foreach (var source in sources)
        {
            source.volume = PlayerPrefs.GetFloat("SliderVolume");
        }

        // Foreach slider in sliders set their value equal to SliderVolume
        foreach (var slider in sliders)
        {
            slider.value = PlayerPrefs.GetFloat("SliderVolume");
        }
    }


}
