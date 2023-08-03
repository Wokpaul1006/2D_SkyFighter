using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorySC : MonoBehaviour
{
    [SerializeField] List<GameObject> dmgList = new List<GameObject>();
    [SerializeField] List<GameObject> hpList = new List<GameObject>();
    [SerializeField] List<GameObject> spdList = new List<GameObject>();
    [SerializeField] List<GameObject> rechargeList = new List<GameObject>();

    private int dmgIndex;
    private int hpIndex;
    private int spdIndex;
    private int rechargeIndex;

    private int dmgCur;
    private int hpCur;
    private int spdCur;
    private int rechargeCur;
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
    void Update()
    {

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

        print("in dmg");
    }
    public void HealthUpHandle()
    {
        hpIndex++;
        hpList[hpIndex].SetActive(true);

        print("in hp");
    }
    public void SpeedUpHandle()
    {
        spdIndex++;
        spdList[spdIndex].SetActive(true);

        print("in spd");
    }
    public void RechargeUpHandle()
    {
        rechargeIndex++;
        rechargeList[rechargeIndex].SetActive(true);

        print("in recharge");
    }
}
