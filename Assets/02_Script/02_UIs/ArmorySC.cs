using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorySC : MonoBehaviour
{
    [SerializeField] List<GameObject> dmgList = new List<GameObject>();
    [SerializeField] List<GameObject> hpList = new List<GameObject>();
    [SerializeField] List<GameObject> spdList = new List<GameObject>();
    [SerializeField] List<GameObject> rechargeList = new List<GameObject>();

    [SerializeField] Text curDmgPriceTxt;
    [SerializeField] Text curHPPriceTxt;
    [SerializeField] Text curSpdPriceTxt;
    [SerializeField] Text curRegenPriceTxt;

    private int dmgIndex;
    private int hpIndex;
    private int spdIndex;
    private int rechargeIndex;

    private int dmgCur;
    private int hpCur;
    private int spdCur;
    private int rechargeCur;

    private int curDmgPrice;
    private int curhpPrice;
    private int curspdPrice;
    private int curRegenPrice;
    void Start()
    {
        dmgIndex = 0;
        hpIndex = 0;
        spdIndex = 0;
        rechargeIndex = 0;
        
        for (int i = 1; i < dmgList.Count; i++)
        {
            dmgList[i].SetActive(false);
        }

        for (int i = 1; i < hpList.Count; i++)
        {
            hpList[i].SetActive(false);
        }

        for (int i = 1; i < spdList.Count; i++)
        {
            spdList[i].SetActive(false);
        }

        for (int i = 1; i < rechargeList.Count; i++)
        {
            rechargeList[i].SetActive(false);
        }
    }
    #region gameplay handle
    void GetPlayer()
    {
        dmgCur = PlayerPrefs.GetInt("CurUpgradeDmg");
        hpCur = PlayerPrefs.GetInt("CurUpgradeDmg");
        spdCur = PlayerPrefs.GetInt("CurUpgradeDmg");
        rechargeCur = PlayerPrefs.GetInt("CurUpgradeDmg");
    }
    void DecideShowDmg()
    {

    }
    void DecideShowHP()
    {

    }
    void DecideShowSP()
    {

    }
    void DecideShowRechager()
    {

    }
    #endregion

    public void DamageUpHandle()
    {
        dmgIndex++;
        dmgList[dmgIndex].SetActive(true);

        if(dmgIndex == 1)
        {
            curDmgPriceTxt.text = curDmgPrice.ToString();
        }
        else
        {
            curDmgPriceTxt.text = (curDmgPrice * dmgIndex * 10).ToString();
        }
    }
    public void HealthUpHandle()
    {
        hpIndex++;
        hpList[hpIndex].SetActive(true);

        if (curhpPrice == 1)
        {
            curHPPriceTxt.text = curhpPrice.ToString();
        }
        else
        {
            curHPPriceTxt.text = (curhpPrice * curhpPrice * 10).ToString();
        }

    }
    public void SpeedUpHandle()
    {
        spdIndex++;
        spdList[spdIndex].SetActive(true);

        if (spdIndex == 1)
        {
            curSpdPriceTxt.text = curspdPrice.ToString();
        }
        else
        {
            curSpdPriceTxt.text = (curspdPrice * spdIndex * 10).ToString();
        }
    }
    public void RechargeUpHandle()
    {
        rechargeIndex++;
        rechargeList[rechargeIndex].SetActive(true);

        if (rechargeIndex == 1)
        {
            curRegenPriceTxt.text = curRegenPrice.ToString();
        }
        else
        {
            curRegenPriceTxt.text = (curRegenPrice * rechargeIndex * 10).ToString();
        }
    }
}
