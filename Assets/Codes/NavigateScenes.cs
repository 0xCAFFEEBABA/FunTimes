using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateScenes : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("cardGame");
    }

    public void ChooseDecks()
    {
        SceneManager.LoadScene("chooseDecks");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
