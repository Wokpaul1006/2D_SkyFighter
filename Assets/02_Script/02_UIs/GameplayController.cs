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
        OnCheckLevel(gpLevel);
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
    private void OnCheckLevel(int inputLvl)
    {
        lvlTxt.text = gpLevel.ToString();
        spawn.SpawnPerShot();

    }
    private void OnUpdateLevel()
    {
        if(enemiesKilled == 10)
        {
            gpLevel = 2;
            OnCheckLevel(gpLevel);
        }else if(enemiesKilled == gpLevel * 10)
        {
            gpLevel++;
            enemiesKilled = 0;
            OnCheckLevel(gpLevel);
        }
    }
    private void OnUpdatePlayerStatus()
    {
        hpTxt.text = player.hpCur.ToString();
        ammoTxt.text = player.ammoCur.ToString();
        apTxt.text = player.apCur.ToString();

        hpImg.fillAmount = 1;
        ammoImg.fillAmount = 1;
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
    
    //void OnSpawn()
    //{
    //    if (inputLvl > 8)
    //    {
    //        spawn.CancelInvoke("SpawnChrono");
    //        spawn.SpawnKamikaze();
    //        spawn.SpawnPerShot();
    //        spawn.SpawnDualShot();
    //        spawn.SpawnConeShot();
    //        spawn.SpawnDiagonal();
    //        spawn.SpawnRandom();
    //        spawn.SpawnChrono();
    //    }
    //    else
    //    {
    //        switch (inputLvl)
    //        {
    //            case 1:
    //                spawn.SpawnKamikaze();
    //                break;
    //            case 2:
    //                spawn.CancelInvoke("SpawnKamikaze");
    //                spawn.SpawnPerShot();
    //                break;
    //            case 3:
    //                spawn.CancelInvoke("SpawnPerShot");
    //                spawn.SpawnDualShot();
    //                break;
    //            case 4:
    //                spawn.CancelInvoke("SpawnDualShot");
    //                spawn.SpawnConeShot();
    //                break;
    //            case 5:
    //                spawn.CancelInvoke("SpawnConeShot");
    //                spawn.SpawnDiagonal();
    //                break;
    //            case 6:
    //                spawn.CancelInvoke("SpawnDiagonal");
    //                spawn.SpawnRandom();
    //                break;
    //            case 7:
    //                spawn.CancelInvoke("SpawnRandom");
    //                spawn.SpawnChrono();
    //                break;
    //        }
    //    }
    //}
}
