using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSC : MonoBehaviour
{
    public void ToGameplay()
    {
        SceneManager.LoadScene("Playground");
    }
}
