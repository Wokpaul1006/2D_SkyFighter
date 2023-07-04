using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionPanel : MonoBehaviour
{
    public void OnBackMainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnReplay()
    {
        SceneManager.LoadScene("Playground");
    }

    public void OnExitGame()
    {
        Application.Quit();
    }
}
