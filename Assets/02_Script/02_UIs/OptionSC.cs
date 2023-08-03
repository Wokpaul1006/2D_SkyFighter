using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSC : Singleton<OptionSC>
{
    [SerializeField] Image onLound, onMute;

    [Header("Variables")]
    private bool isSound;
    private bool isVibrate;
    void Start()
    {
        OnStartGame();
    }

    void OnStartGame()
    {
        isSound = true;
        isVibrate = true;
        onLound.gameObject.SetActive(true);
    }
    void Update()
    {
        
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
            Handheld.Vibrate();
        }
    }
}
