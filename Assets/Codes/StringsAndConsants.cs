using UnityEditor;

using UnityEngine;
/// <summary>
/// A class that contains all string variables and constants
/// </summary>
public class StringsAndConsants
{
    /// <summary>
    /// 'cards'
    /// </summary>
    public const string cards = "cards";
    /// <summary>
    /// 'EN' for English
    /// </summary>
    public const string EN = "EN";
    /// <summary>
    /// 'GR' for Greek
    /// </summary>
    public const string GR = "GR";
    /// <summary>
    /// The dark theme's tag
    /// </summary>
    public const string darkTheme = "DarkTheme";
    /// <summary>
    /// The light theme's tag
    /// </summary>
    public const string lightTheme = "LightTheme";

    #region FileLocations
    
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
    /// Location for all toggle and button images for the previews.
    /// </summary>
    public static string previewsLocation = $"Previews/";
    
    /// <summary>
    /// Location for all button images for the 'mainMenu' scene's light theme.
    /// </summary>
    public static string mainMenuLocationLight = $"{mainMenuScene}/{lightTheme}/";
    
    /// <summary>
    /// Location for all button images for the 'mainMenu' scene's dark theme.
    /// </summary>
    public static string mainMenuLocationDark = $"{mainMenuScene}/{darkTheme}/";
    
    #endregion
    
    #region Button Images Names
    
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
    /// The hamburger button image's name in the resources
    /// </summary>
    public const string humburgerButtonName = "humburgerMenu";
    
    /// <summary>
    /// The arrow button image's name in the resources
    /// </summary>
    public const string arrowButtonName = "backArrow";
    
    /// <summary>
    /// The next button image's name in the resources
    /// </summary>
    public const string nextButtonName = "nextBtn";
    
    /// <summary>
    /// Name of the instructions 
    /// </summary>
    public const string instructionsName = "Instructions";

    #region Preview Close Button Image Names

    /// <summary>
    /// Close button for sexy preview
    /// </summary>
    public const string sexyPreviewClose = "sexyX";

    /// <summary>
    /// Close button for macho preview
    /// </summary>
    public const string machoPreviewClose = "machoX";

    /// <summary>
    /// Close button for girly preview
    /// </summary>
    public const string girlyPreviewClose = "girlyX";

    /// <summary>
    /// Close button for daring preview
    /// </summary>
    public const string daringPreviewClose = "daringX";

    /// <summary>
    /// Close button for school preview
    /// </summary>
    public const string schoolPreviewClose = "schoolX";

    #endregion

    #region Preview Cards Image Name

    /// <summary>
    /// Buy button for sexy preview
    /// </summary>
    public const string sexyPreviewBuy = "sexyBuy";

    /// <summary>
    /// Buy button for macho preview
    /// </summary>
    public const string machoPreviewBuy = "machoBuy";

    /// <summary>
    /// Buy button for girly preview
    /// </summary>
    public const string girlyPreviewBuy = "girlyBuy";

    /// <summary>
    /// Buy button for daring preview
    /// </summary>
    public const string daringPreviewBuy = "daringBuy";

    /// <summary>
    /// Buy button for school preview
    /// </summary>
    public const string schoolPreviewBuy = "schoolBuy";
    #endregion

    #endregion

    #region SceneNames
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
    #endregion
    
    #region ToggleNames
    /// <summary>
    /// family toggle name in unity
    /// </summary>
    public const string familyToggleName = "familyTimeToggle";
    /// <summary>
    /// family toggle's tag in unity
    /// </summary>
    public const string sexyToggleName = "sexyTimeToggle";
    /// <summary>
    /// sexy toggle's tag in unity
    /// </summary>
    public const string machoToggleName = "machoTimeToggle";
    /// <summary>
    /// girly toggle's tag in unity
    /// </summary>
    public const string girlyToggleName = "girlyTimeToggle";
    /// <summary>
    /// daring toggle's tag in unity
    /// </summary>
    public const string daringToggleName = "daringTimeToggle";
    /// <summary>
    /// school toggle's tag in unity
    /// </summary>
    public const string schoolToggleName = "schoolTimeToggle";

    /// <summary>
    /// The toggle name without the category
    /// </summary>
    public const string toggleName = "TimeToggle";

    #endregion

    #region ButtonTags
    //------ For Buttons ------
    /// <summary>
    /// The next button's tag
    /// </summary>
    public const string nextButtonTag = "NextButton";
    /// <summary>
    /// The play button's tag
    /// </summary>
    public const string playButtonTag = "PlayButton";
    /// <summary>
    /// The choose decks button's tag
    /// </summary>
    public const string chooseDecksTag = "ChooseDecksButton";
    /// <summary>
    /// The back button's tag
    /// </summary>
    public const string backButtonTag = "BackButton";
    /// <summary>
    /// The main menu button's tag
    /// </summary>
    public const string mainMenuButtonTag = "MainMenuButton";
    /// <summary>
    /// The side button's tag
    /// </summary>
    public const string sideMenuButtonTag = "SideMenuButton";
    /// <summary>
    /// The tag for the instructions image
    /// </summary>
    public const string instructionsTag = "InstructionsImageTag";

    #region Preview Tags



    #endregion

    #endregion

    #region CardDimensions
    /// <summary>
    /// The default width of every card.
    /// </summary>
    public const float cardWidth = 723.6016f;
    /// <summary>
    /// The default height of every card.
    /// </summary>
    public const float cardHeight = 1078.129f;
    #endregion
}
