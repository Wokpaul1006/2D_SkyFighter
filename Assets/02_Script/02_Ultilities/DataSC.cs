using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSC : Singleton<DataSC>
{
    private string nameFistPlay;
    private string playerName;
    private int playerHighscore;
    private int hasPlayed; //Use this variable for check FirstPlay.
    void Start()
    {
        hasPlayed = PlayerPrefs.GetInt("HasPlayed");
        OnCheckPlay();
    }
    #region Check if Player First Play or not
    private void OnCheckPlay()
    {
        if (hasPlayed == 0)
        {
            //Case of first play, set this field to 1 mean not first play any more
            PlayerPrefs.SetInt("HasPlayed", 1); 
            SetNewPlayer();
        }
        else if(hasPlayed == 1)
        {
            //Case of not First Play
            LoadOldPlayer(); 
        }
    }
    private void SetNewPlayer()
    {
        if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            nameFistPlay = "PlayerTest" ;
        }else if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) 
        {
            nameFistPlay = "Player" + (Random.Range(100000, 30000)).ToString();
        }

        PlayerPrefs.SetString("Player", nameFistPlay);
        PlayerPrefs.SetInt("Highscore", 0);
    }
    public void LoadOldPlayer()
    {
        //This function load player information if there are not FIRST PLAY
        playerName = PlayerPrefs.GetString("PlayerName");
        playerHighscore = PlayerPrefs.GetInt("Highscore");
    }
    public void ClearPlayer() { PlayerPrefs.DeleteAll(); }
    #endregion
}
