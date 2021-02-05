using Newtonsoft.Json.Linq;
using UnityEngine;

public class Data
{
    /// <summary>
    /// The name of the category
    /// </summary>
    public CategoryEnum Category { get; set; }

    /// <summary>
    /// Tells if a category is locked or not
    /// The default value is true
    /// </summary>
    public bool IsLocked { get; set; } = true;

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
    /// An array that contains all tasks from a specific JSON file
    /// </summary>
    public string[] TaskArray { get; set; }
   /// <summary>
   /// The language for the data and game
   /// </summary>
    public LanguageEnum Language { get; set; }

    /// <summary>
    /// The category's preview card
    /// </summary>
    public PreviewCard PreviewCard { get; set; }
}
