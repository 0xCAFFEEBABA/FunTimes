using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateScenes : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(StringsAndConsants.cardGameScene);
    }

    public void ChooseDecks()
    {
        SceneManager.LoadScene(StringsAndConsants.chooseDecksScene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(StringsAndConsants.mainMenuScene);
    }
}
