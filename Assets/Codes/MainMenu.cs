using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("cardGame");
    }

    public void ChooseDecks()
    {
        SceneManager.LoadScene("chooseDecks");
    }
}
