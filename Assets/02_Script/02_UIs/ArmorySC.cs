using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorySC : MonoBehaviour
{
    [SerializeField] List<GameObject> dmgList = new List<GameObject>();
    [SerializeField] List<GameObject> hpList = new List<GameObject>();
    [SerializeField] List<GameObject> mgzSizeList = new List<GameObject>();
    [SerializeField] List<GameObject> rechargeList = new List<GameObject>();

    [SerializeField] Text curDmgPriceTxt;
    [SerializeField] Text curHPPriceTxt;
    [SerializeField] Text curMagazineSizeTxt;
    [SerializeField] Text curRegenPriceTxt;

    private int dmgIndex; //index of Damage to visible 
    private int hpIndex; //index of HP to visible 
    private int mgzSizeIndex; //index of magazine to visible 
    private int rechargeIndex; //index of Regeneration to visible 

    private int dmgCur; //use this to interact with PlayerPrefs
    private int hpCur; //use this to interact with PlayerPrefs
    private int mgzCur; //use this to interact with PlayerPrefs
    private int rechargeCur; //use this to interact with PlayerPrefs

    private int curDmgPrice;
    private int curhpPrice;
    private int curmgzPrice;
    private int curRegenPrice;

    private string priceUnit = "C";
    private void Awake()
    {
        GetPlayer();
    }
    void Start()
    {
        dmgIndex = dmgCur;
        hpIndex = hpCur;
        mgzSizeIndex = mgzCur;
        rechargeIndex = rechargeCur;

        for (int i = 1; i < dmgList.Count; i++)
        {
            dmgList[i].SetActive(false);
        }

        for (int i = 1; i < hpList.Count; i++)
        {
            hpList[i].SetActive(false);
        }

        for (int i = 1; i < mgzSizeList.Count; i++)
        {
            mgzSizeList[i].SetActive(false);
        }

        for (int i = 1; i < rechargeList.Count; i++)
        {
            rechargeList[i].SetActive(false);
        }

        DecideShowDmg();
        DecideShowHP();
        DecideShowRechager();
        DecideShowSP();
    }
    #region gameplay handle
    void GetPlayer()
    {
        dmgCur = PlayerPrefs.GetInt("CurUpgradeDmg");
        hpCur = PlayerPrefs.GetInt("CurUpgradeHP");
        mgzCur = PlayerPrefs.GetInt("CurUpgradeMgz");
        rechargeCur = PlayerPrefs.GetInt("CurUpgradeRegen");
    }
    void DecideShowDmg()
    {
        for(int i = 0; i <= dmgCur; i++)
        {
            dmgList[i-1].SetActive(true);
        }
    }
    void DecideShowHP()
    {
        for (int i = 0; i <= hpCur; i++)
        {
            hpList[i-1].SetActive(true);
        }
    }
    void DecideShowSP()
    {
        for (int i = 0; i <= mgzCur; i++)
        {
            mgzSizeList[i-1].SetActive(true);
        }
    }
    void DecideShowRechager()
    {
        for (int i = 0; i <= rechargeCur; i++)
        {
            rechargeList[i-1].SetActive(true);
        }
    }
    #endregion

    public void DamageUpHandle()
    {
        if(dmgIndex <= 5)
        {
            dmgIndex++;
            dmgList[dmgIndex].SetActive(true);
            PlayerPrefs.SetInt("CurUpgradeDmg", dmgIndex);
            curDmgPrice = dmgIndex * 10;

            if (dmgIndex == 1)
            {
                curDmgPriceTxt.text = curDmgPrice.ToString() + priceUnit;
            }
            else
            {
                curDmgPriceTxt.text = (curDmgPrice * dmgIndex * 10).ToString() + priceUnit;
            }
        }
        else if(dmgIndex>= 5)
        {
            curDmgPriceTxt.text = "MAX OUT";
        }
    }
    public void HealthUpHandle()
    {
        if(hpIndex <= 5)
        {
            hpIndex++;
            hpList[hpIndex].SetActive(true);
            PlayerPrefs.SetInt("CurUpgradeHP", hpIndex);
            curhpPrice = hpIndex * 10;

            if (hpIndex == 1)
            {
                curHPPriceTxt.text = curhpPrice.ToString() + priceUnit;
            }
            else
            {
                curHPPriceTxt.text = (curhpPrice * curhpPrice * 10).ToString() + priceUnit;
            }
        }
        else if(hpIndex >= 5)
        {
            curHPPriceTxt.text = "MAX OUT";
        }
    }
    public void MgzSizeHandle()
    {
        if(mgzSizeIndex <= 5)
        {
            mgzSizeIndex++;
            mgzSizeList[mgzSizeIndex].SetActive(true);
            PlayerPrefs.SetInt("CurUpgradeMgz", mgzSizeIndex);
            curmgzPrice = mgzSizeIndex * 10;

            if (mgzSizeIndex == 1)
            {
                curMagazineSizeTxt.text = curmgzPrice.ToString() + priceUnit;
            }
            else
            {
                curMagazineSizeTxt.text = (curmgzPrice * mgzSizeIndex * 10).ToString();
            }
        }
        else if (mgzSizeIndex >= 5)
        {
            curMagazineSizeTxt.text = "MAX OUT";
        }

    }
    public void RechargeUpHandle()
    {
        if(rechargeIndex <= 5 )
        {
            rechargeIndex++;
            rechargeList[rechargeIndex].SetActive(true);
            PlayerPrefs.SetInt("CurUpgradeRegen", rechargeIndex);
            curRegenPrice = mgzSizeIndex * 10;

            if (rechargeIndex == 1)
            {
                curRegenPriceTxt.text = curRegenPrice.ToString() + priceUnit;
            }
            else
            {
                curRegenPriceTxt.text = (curRegenPrice * rechargeIndex * 10).ToString();
            }
        }
        else if (rechargeIndex >= 5)
        {
            curRegenPriceTxt.text = "MAX OUT";
        }
    }
}
