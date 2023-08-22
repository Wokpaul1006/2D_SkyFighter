using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoSC : MonoBehaviour
{
    [SerializeField] DataSC data;

    [SerializeField] Text playerName;
    [SerializeField] Text curHighScore;
    [SerializeField] Text totalScore;

    [SerializeField] Text curDmglvl;
    [SerializeField] Text curHPLvl;
    [SerializeField] Text curAmmmoLvl;
    [SerializeField] Text curRegentLvl;

    void Start()
    {
        data = GameObject.Find("PlayerData").GetComponent<DataSC>();
    }
    public void SetPlayerInfo(string name, int highScore, int coin)
    {
        playerName.text = data.playerName;
        curHighScore.text = data.playerHighscore.ToString();
        totalScore.text = data.playerTotalScore.ToString();
    }

    public void SetPlayerStat(int dmg, int hp, int ammo, int regent)
    {
        curDmglvl.text = data.curDmgLevel.ToString();
        curHPLvl.text = data.curHealthLevel.ToString();
        curAmmmoLvl.text = data.curAmmoLevel.ToString();
        curRegentLvl.text = data.curRegentLevel.ToString();
    }
    public void UpdatePlayerStat()
    {
        curDmglvl.text = data.curDmgLevel.ToString();
        curHPLvl.text = data.curHealthLevel.ToString();
        curAmmmoLvl.text = data.curAmmoLevel.ToString();
        curRegentLvl.text = data.curRegentLevel.ToString();
    }
}
