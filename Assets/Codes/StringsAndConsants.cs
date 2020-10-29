/// <summary>
/// A class that contains all string variables and constants
/// </summary>
public class StringsAndConsants
{
    //------ Locations ------
    /// <summary>
    /// Location for all card images and buttons for the light theme.
    /// </summary>
    public static string cardGameLocationLight = $"{cardGameScene}/{lightTheme}/";
    /// <summary>
    /// Location for all card images and buttons for the dark theme.
    /// </summary>
    public static string cardGameLocationDark = $"{cardGameScene}/{darkTheme}/";
    /// <summary>
    /// Location for all buttons for the light theme.
    /// </summary>
    public static string decksLocationLight = $"{chooseDecksScene}/{lightTheme}/";
    /// <summary>
    /// Location for all buttons images for the dark theme.
    /// </summary>
    public static string decksLocationDark = $"{chooseDecksScene}/{darkTheme}/";
    /// <summary>
    /// 
    /// </summary>
    public const string cards = "cards";
    public const string EN = "EN";
    public const string GR = "GR";
    public const string playButtonName = "play";
    public const string mainMenuButtonName = "mainMenu";
    public const string nextButtonName = "nextBtn";
    //------ Scene Names ------
    public const string cardGameScene = "cardGame";
    public const string chooseDecksScene = "chooseDecks";
    public const string mainMenuScene = "mainMenu";
    //------ Tags ------
    public const string familyToggleTag = "FamilyTimeToggle";
    public const string sexyToggleTag = "SexyTimeToggle";
    public const string machoToggleTag = "MachoTimeToggle";
    public const string girlyToggleTag = "GirlyTimeToggle";
    public const string daringToggleTag = "DaringTimeToggle";
    public const string schoolToggleTag = "SchoolTimeToggle";
    public const string nextButtonTag = "NextButton";
    public const string playButtonTag = "PlayButton";
    public const string mainMenuButtonTag = "MainMenuButton";

    public const string darkTheme = "DarkTheme";
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
