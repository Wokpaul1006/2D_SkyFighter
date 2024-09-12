using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OmniMN : Singleton<OmniMN>
{
    //This calss control all back-end activities of client
    void Start()
    {
        hasPlayed = PlayerPrefs.GetInt("HasPlayed");
        OnCheckPlay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChangeScene(sbyte sceneOder)
    {
        switch (sceneOder)
        {
            case 0: //To Mainmenu
                SceneManager.LoadScene("1_MainScene");
                break;
            case 1:
                SceneManager.LoadScene("StoryScene");
                break;
            case 2:
                SceneManager.LoadScene("ArenaScene");
                break;
            case 3:
                SceneManager.LoadScene("PvPScene");
                break;
            case 4:
                SceneManager.LoadScene("");
                break;
            case 5:
                //Send request to server that player Quit game
                Application.Quit();
                break;
        }
    }

    public string nameFistPlay;
    public string playerName;
    public int playerHighscore;
    public int playerTotalScore;

    public int curDmgLevel;
    public int curHealthLevel;
    public int curAmmoLevel;
    public int curRegentLevel;

    private int curEnemiesSelected;
    private int curWeaponSelected;
    private int curAbilitySelected;

    private int hasPlayed; //Use this variable for check FirstPlay.

    #region Check if Player First Play or not
    private void OnCheckPlay()
    {
        if (hasPlayed == 0)
        {
            //Case of first play, set this field to 1 mean not first play any more
            PlayerPrefs.SetInt("HasPlayed", 1);
            SetNewPlayer();
        }
        else if (hasPlayed == 1)
        {
            //Case of not First Play
            LoadOldPlayer();
        }
    }
    private void SetNewPlayer()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            nameFistPlay = "PlayerTest";
        }
        else if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            nameFistPlay = "Player" + (Random.Range(100000, 30000)).ToString();
        }

        PlayerPrefs.SetString("PlayerName", nameFistPlay);
        PlayerPrefs.SetInt("Highscore", 0);
        PlayerPrefs.SetInt("Totalscore", 0);
        PlayerPrefs.SetInt("CurEnemies", 0);
        PlayerPrefs.SetInt("CurWeapon", 0);
        PlayerPrefs.SetInt("CurAblility", 0);

        PlayerPrefs.SetInt("CurUpgradeDmg", 1);
        PlayerPrefs.SetInt("CurUpgradeHP", 1);
        PlayerPrefs.SetInt("CurUpgradeMgz", 1);
        PlayerPrefs.SetInt("CurUpgradeRegen", 1);
    }
    public void LoadOldPlayer()
    {
        //This function load player information if there are not FIRST PLAY
        playerName = PlayerPrefs.GetString("PlayerName");
        playerHighscore = PlayerPrefs.GetInt("Highscore");
        playerTotalScore = PlayerPrefs.GetInt("Totalscore");
        curEnemiesSelected = PlayerPrefs.GetInt("CurEnemies");
        curWeaponSelected = PlayerPrefs.GetInt("CurWeapon");
        curAbilitySelected = PlayerPrefs.GetInt("CurAblility");

        curDmgLevel = PlayerPrefs.GetInt("CurUpgradeDmg");
        curHealthLevel = PlayerPrefs.GetInt("CurUpgradeHP");
        curAmmoLevel = PlayerPrefs.GetInt("CurUpgradeMgz");
        curRegentLevel = PlayerPrefs.GetInt("CurUpgradeRegen");
    }
    public void ClearPlayer() { PlayerPrefs.DeleteAll(); }
    #endregion
}
