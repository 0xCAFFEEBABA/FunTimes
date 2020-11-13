using UnityEditor;

using UnityEngine;
/// <summary>
/// A class that contains all string variables and constants
/// </summary>
public class StringsAndConsants
{
    //------ Locations ------
    /// <summary>
    /// Location for all card images and buttons for the 'cardGame' scene's light theme.
    /// </summary>
    public static string cardGameLocationLight = $"{cardGameScene}/{lightTheme}/";
    /// <summary>
    /// Location for all card images and buttons for the 'cardGame' scene's dark theme.
    /// </summary>
    public static string cardGameLocationDark = $"{cardGameScene}/{darkTheme}/";
    /// <summary>
    /// Location for all toggle and button images for the 'chooseDecks' scene's light theme.
    /// </summary>
    public static string decksLocationLight = $"{chooseDecksScene}/{lightTheme}/";
    /// <summary>
    /// Location for all toggle and button images for the 'chooseDecks' scene's dark theme.
    /// </summary>
    public static string decksLocationDark = $"{chooseDecksScene}/{darkTheme}/";
    /// <summary>
    /// Location for all button images for the 'mainMenu' scene's light theme.
    /// </summary>
    public static string mainMenuLocationLight = $"{mainMenuScene}/{lightTheme}/";
    /// <summary>
    /// Location for all button images for the 'mainMenu' scene's dark theme.
    /// </summary>
    public static string mainMenuLocationDark = $"{mainMenuScene}/{darkTheme}/";

    /// <summary>
    /// Location for backArrow image
    /// </summary>
    public static string backArrow = "backArrow";

    /// <summary>
    /// Location for humburger image
    /// </summary>
    public static string humburger = "humburgerMenu";
    /// <summary>
    /// 'cards'
    /// </summary>
    public const string cards = "cards";
    /// <summary>
    /// 'EN'
    /// </summary>
    public const string EN = "EN";
    /// <summary>
    /// 'GR'
    /// </summary>
    public const string GR = "GR";
    /// <summary>
    /// The play button image's name in the resources
    /// </summary>
    public const string playButtonName = "play";
    /// <summary>
    /// The choose decks button image's name in the resources
    /// </summary>
    public const string chooseDecksButtonName = "chooseDecks";
    /// <summary>
    /// The back button image's name in the resources
    /// </summary>
    public const string backButtonName = "back";
    /// <summary>
    /// The main menu button image's name in the resources
    /// </summary>
    public const string mainMenuButtonName = "mainMenu";
    /// <summary>
    /// The next button image's name in the resources
    /// </summary>
    public const string nextButtonName = "nextBtn";
    //------ Scene Names ------
    /// <summary>
    /// Name of the card game scene
    /// </summary>
    public const string cardGameScene = "cardGame";
    /// <summary>
    /// Name of the choose decks scene
    /// </summary>
    public const string chooseDecksScene = "chooseDecks";
    /// <summary>
    /// Name of the main menu scene
    /// </summary>
    public const string mainMenuScene = "mainMenu";
    //------ Tags ------
    //------ For Toggles ------
    /// <summary>
    /// family toggle
    /// </summary>
    public const string familyToggleTag = "FamilyTimeToggle";
    /// <summary>
    /// family toggle's tag in unity
    /// </summary>
    public const string sexyToggleTag = "SexyTimeToggle";
    /// <summary>
    /// sexy toggle's tag in unity
    /// </summary>
    public const string machoToggleTag = "MachoTimeToggle";
    /// <summary>
    /// girly toggle's tag in unity
    /// </summary>
    public const string girlyToggleTag = "GirlyTimeToggle";
    /// <summary>
    /// daring toggle's tag in unity
    /// </summary>
    public const string daringToggleTag = "DaringTimeToggle";
    /// <summary>
    /// school toggle's tag in unity
    /// </summary>
    public const string schoolToggleTag = "SchoolTimeToggle";
    //------ For Buttons ------
    /// <summary>
    /// 
    /// </summary>
    public const string nextButtonTag = "NextButton";
    /// <summary>
    /// 
    /// </summary>
    public const string playButtonTag = "PlayButton";
    /// <summary>
    /// 
    /// </summary>
    public const string chooseDecksTag = "ChooseDecksButton";
    /// <summary>
    /// 
    /// </summary>
    public const string backButtonTag = "BackButton";
    /// <summary>
    /// 
    /// </summary>
    public const string mainMenuButtonTag = "MainMenuButton";
    /// <summary>
    /// 
    /// </summary>
    public const string darkTheme = "DarkTheme";
    /// <summary>
    /// 
    /// </summary>
    public const string lightTheme = "LightTheme";
    //---------- For Card's Dimensions ----------
    /// <summary>
    /// The default width of every card.
    /// </summary>
    public const float cardWidth = 723.6016f;
    /// <summary>
    /// The default height of every card.
    /// </summary>
    public const float cardHeight = 1078.129f;


}
