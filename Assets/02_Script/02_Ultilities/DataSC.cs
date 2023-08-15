using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSC : Singleton<DataSC>
{
    public string nameFistPlay;
    public string playerName;
    public int playerHighscore;
    private int curEnemies;
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

        PlayerPrefs.SetString("PlayerName", nameFistPlay);
        PlayerPrefs.SetInt("Highscore", 0);
        PlayerPrefs.SetInt("CurEnemies", 0);

        PlayerPrefs.SetInt("CurUpgradeDmg", 0);
        PlayerPrefs.SetInt("CurUpgradeHP", 0);
        PlayerPrefs.SetInt("CurUpgradeMgz", 0);
        PlayerPrefs.SetInt("CurUpgradeRegen", 0);
    }
    public void LoadOldPlayer()
    {
        //This function load player information if there are not FIRST PLAY
        playerName = PlayerPrefs.GetString("PlayerName");
        playerHighscore = PlayerPrefs.GetInt("Highscore");
        curEnemies = PlayerPrefs.GetInt("CurEnemies");
    }
    public void ClearPlayer() { PlayerPrefs.DeleteAll(); }
    #endregion
}
