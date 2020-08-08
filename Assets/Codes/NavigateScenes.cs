using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

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
