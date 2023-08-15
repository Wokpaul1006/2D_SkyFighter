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
            dmgList[i].SetActive(true);
        }
    }
    void DecideShowHP()
    {
        for (int i = 0; i <= hpCur; i++)
        {
            hpList[i].SetActive(true);
        }
    }
    void DecideShowSP()
    {
        for (int i = 0; i <= mgzCur; i++)
        {
            mgzSizeList[i].SetActive(true);
        }
    }
    void DecideShowRechager()
    {
        for (int i = 0; i <= rechargeCur; i++)
        {
            rechargeList[i].SetActive(true);
        }
    }
    #endregion

    public void DamageUpHandle()
    {
        if(dmgIndex <= 7)
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
        else
        {
            curDmgPriceTxt.text = "MAX OUT";
        }
    }
    public void HealthUpHandle()
    {
        if(hpIndex <= 7)
        {
            hpIndex++;
            hpList[hpIndex].SetActive(true);
            PlayerPrefs.SetInt("CurUpgradeHP", hpIndex);

            if (hpIndex == 1)
            {
                curHPPriceTxt.text = curhpPrice.ToString() + priceUnit;
            }
            else
            {
                curHPPriceTxt.text = (curhpPrice * curhpPrice * 10).ToString() + priceUnit;
            }
        }
        else
        {
            curHPPriceTxt.text = "MAX OUT";
        }


    }
    public void MgzSizeHandle()
    {
        if(mgzSizeIndex <= 7)
        {
            mgzSizeIndex++;
            mgzSizeList[mgzSizeIndex].SetActive(true);
            PlayerPrefs.SetInt("CurUpgradeMgz", mgzSizeIndex);

            if (mgzSizeIndex == 1)
            {
                curMagazineSizeTxt.text = curmgzPrice.ToString() + priceUnit;
            }
            else
            {
                curMagazineSizeTxt.text = (curmgzPrice * mgzSizeIndex * 10).ToString();
            }
        }
        else
        {
            curMagazineSizeTxt.text = "MAX OUT";
        }

    }
    public void RechargeUpHandle()
    {
        if(rechargeIndex <= 7)
        {
            rechargeIndex++;
            rechargeList[rechargeIndex].SetActive(true);
            PlayerPrefs.SetInt("CurUpgradeRegen", rechargeIndex);

            if (rechargeIndex == 1)
            {
                curRegenPriceTxt.text = curRegenPrice.ToString() + priceUnit;
            }
            else
            {
                curRegenPriceTxt.text = (curRegenPrice * rechargeIndex * 10).ToString();
            }
        }
        else
        {
            curRegenPriceTxt.text = "MAX OUT";
        }
    }
}
