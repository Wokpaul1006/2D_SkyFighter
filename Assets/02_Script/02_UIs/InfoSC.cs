using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoSC : MonoBehaviour
{
    [SerializeField] OmniMN data;

    [SerializeField] Text playerName;
    [SerializeField] Text curHighScore;
    [SerializeField] Text totalScore;

    [SerializeField] Text curDmglvl;
    [SerializeField] Text curHPLvl;
    [SerializeField] Text curAmmmoLvl;
    [SerializeField] Text curRegentLvl;

    void Start()
    {
        data = GameObject.Find("PlayerData").GetComponent<OmniMN>();
    }
    private void Update()
    {
        if (gameObject.activeSelf)
        {
            SetPlayerInfo();
            SetPlayerStat();
        }
    }
    public void SetPlayerInfo()
    {
        playerName.text = data.playerName;
        curHighScore.text = data.playerHighscore.ToString();
        totalScore.text = data.playerTotalScore.ToString();
    }

    public void SetPlayerStat()
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
