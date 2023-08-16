using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] PlayerSript player;
    [SerializeField] SpawnerSC spawn;
    [SerializeField] Text lvlTxt;
    [SerializeField] Text minTxt, secTxt;
    [SerializeField] Text hpTxt, ammoTxt, apTxt;
    [SerializeField] Image hpImg, ammoImg, apImg;

    [Header("Variables")]
    public float gpHP, gpAP, gpExp;
    public int gpLevel;
    private int sec, min;
    public int enemiesKilled;

    void Start()
    {
        gpLevel = 1; //Min = 1; Max = ?
        SpawnPlayer();
        OnShowLevel(gpLevel);
        OnSelectEnemiesToSpawn();
        StartCoroutine(CountSec());
    }

    private void Update()
    {
        TimeCount();
        OnUpdateLevel();
        OnUpdatePlayerStatus();
    }

    #region Handle gameplay activity
    private void SpawnPlayer() => player = Instantiate(player, Vector3.zero, Quaternion.identity);
    private void OnShowLevel(int inputLvl) => lvlTxt.text = gpLevel.ToString();
    private void OnUpdateLevel()
    {
        if(enemiesKilled == 10)
        {
            gpLevel = 2;
            OnShowLevel(gpLevel);
        }else if(enemiesKilled == gpLevel * 10)
        {
            gpLevel++;
            enemiesKilled = 0;
            OnShowLevel(gpLevel);
        }
    }
    private void OnUpdatePlayerStatus()
    {
        hpTxt.text = player.hpCur.ToString();
        ammoTxt.text = player.ammoCur.ToString();
        apTxt.text = player.apCur.ToString();

        hpImg.fillAmount = player.hpCur/player.hpMaxLoad;
        ammoImg.fillAmount = player.ammoCur / player.ammoMaxLoad;
        apImg.fillAmount = 0;
    }
    #endregion

    #region UIs activities
    private void TimeCount()
    {
        if (sec < 10)
        {
            secTxt.text = "0" + sec.ToString();
        }
        else
        {
            secTxt.text = sec.ToString();
        }

        if (min < 10)
        {
            minTxt.text = "0" + min.ToString();
        }
        else
        {
            minTxt.text = min.ToString();
        }
    }
    private IEnumerator CountSec()
    {
        yield return new WaitForSeconds(1);
        sec++;
        if (sec == 60) { CountMin(); }
        StartCoroutine(CountSec());
    }
    private void CountMin()
    {
        min++;
        sec = 0;
    }
    #endregion

    void OnSelectEnemiesToSpawn()
    {
        StartCoroutine(spawn.SpawnEnemies(PlayerPrefs.GetInt("CurEnemies")));
    }

    #region Brainstom gameplay flow
    //Game start => Player appear:
    //  + Start level always = 0
    //  + Enemies to spawn is enemies that player bought from shop
    //  + Number of Enemies and spawning speed is base on level

    #endregion
}
