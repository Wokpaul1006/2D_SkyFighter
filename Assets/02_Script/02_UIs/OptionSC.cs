using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSC : Singleton<OptionSC>
{
    [SerializeField] Image onLound, onMute;

    [Header("Variables")]
    private bool isSound; //manage theme of the game
    private bool isEffect; //manage effect of the gameplay such like shooting sound or exploding sound
    private bool isVibrate; //manage vibrate of game when exploision init
    void Start() => OnStartGame();
    void OnStartGame()
    {
        isSound = true;
        isVibrate = true;
        isEffect = true;

        onLound.gameObject.SetActive(true);
    }
    public void OnSoundClick()
    {
        if(isSound == true) 
        {
            //Case of turn off sound
            isSound = false;
            onLound.gameObject.SetActive(false);
            onMute.gameObject.SetActive(true);
        }
        else
        {
            //Case of turn on sound
            isSound = true;
            onLound.gameObject.SetActive(true);
            onMute.gameObject.SetActive(false);
        }
    }
    public void OnVibrateClick()
    {
        if(isVibrate == true) { isVibrate = false; }
        else 
        {
            isVibrate = true;
            //Handheld.Vibrate();
        }
    }
    public void OnLangueClick()
    {
        //Change langues function
    }
    public void OnProfileClick()
    {
        //Alredy set in editor
    }
    public void OnFBClick()
    {
        //Log in by Facebook
    }
    public void OnGoogleClick()
    {
        //Login by Gmail
    }
    public void OnExitClick()
    {
        Application.Quit(0);
    }
}
