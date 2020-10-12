using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    //public Slider slider;
    float musicVolume = 1f;
    private AudioSource[] sources;


    // to control slider
    public void ChangeSlider(float newVolume)
    {
        musicVolume = newVolume;
        PlayerPrefs.SetFloat("SliderVolume", musicVolume);
    }


    void Update()
    {
        sources = FindObjectsOfType<AudioSource>();

        foreach(var source in sources)
        {
            source.volume = PlayerPrefs.GetFloat("SliderVolume");
        }
    }


}
