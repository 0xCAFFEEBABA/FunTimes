using LitJson;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data
{
    /// <summary>
    /// The name of the category
    /// </summary>
    public string Category { get; set; }
    /// <summary>
    /// A boolean value for whether the toggle is on or not
    /// </summary>
    public bool ToggleBool { get; set; }
    /// <summary>
    /// The card image for the light theme
    /// </summary>
    public Sprite LightImage { get; set; }
    /// <summary>
    /// The card image for the dark theme
    /// </summary>
    public Sprite DarkImage { get; set; }
    /// <summary>
    /// Contains the data from the corresponding JSON file
    /// </summary>
    public JObject JsonData { get; set; }
    /// <summary>
    /// The number of elements inside the JSON file's array
    /// </summary>
    public int Length { get; set; }
   /// <summary>
   /// The language for the data and game
   /// </summary>
    public LanguageEnum Language { get; set; }
   



}
