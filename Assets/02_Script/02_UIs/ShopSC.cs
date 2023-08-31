using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSC : MonoBehaviour
{
    [SerializeField] Text coinText;
    private int curCoinForPurchase = 0;
    private void Start()
    {
        curCoinForPurchase = PlayerPrefs.GetInt("Totalscore");
        UpdateCoinText(curCoinForPurchase);
    }
    private void UpdateCoinText(int valueToUpdate) => coinText.text = valueToUpdate.ToString() + "C";
    #region Enemies Panel
    public void OnBuyPerShot()
    {
        int price = 100;
        if (CheckBuy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurEnemies", 1);
        }
    }
    public void OnBuyDualShot()
    {
        int price = 200;
        if (CheckBuy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurEnemies", 2);
        }
    }
    public void OnBuyConeShot()
    {
        int price = 400;
        if (CheckBuy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurEnemies", 3);
        }
    }
    public void OnBuyBouncer()
    {
        int price = 800;
        if (CheckBuy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurEnemies", 4);
        }
    }
    public void OnBuyRandompath()
    {
        int price = 1600;
        if (CheckBuy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurEnemies", 5);
        }
    }
    public void OnBuyChronoshift()
    {
        int price = 3200;
        if (CheckBuy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurEnemies", 6);
        }
    }
    #endregion

    #region Weapon Panel
    public void OnBuyDoubleBullet()
    {
        int price = 100;
        if (CheckBuy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurWeapon", 1);
        }
    }
    public void OnBuyTripleBullet()
    {
        int price = 100;
        if (CheckBuy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurWeapon", 1);
        }

    }
    public void OnBuyFanlikeWarhead()
    {
        int price = 100;
        if (CheckBuy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurWeapon", 1);
        }
    }
    #endregion

    #region Buy Ability
    public void OnBuyAOEMissle()
    {
        int price = 100;
        if (CheckBuy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurAblility", 1);
        }
    }
    public void OnBuyInlineMissle()
    {
        int price = 100;
        if (CheckBuy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurAblility", 1);
        }
    }
    public void OnBuyProtectShile()
    {
        int price = 100;
        if (CheckBuy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurAblility", 1);
        }
    }
    public void OnBuyRoundMissle()
    {
        int price = 100;
        if (CheckBuy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurAblility", 1);
        }
    }
    public void OnBuyFreezingTime()
    {
        int price = 100;
        if (CheckBuy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurAblility", 1);
        }
    }
    #endregion

    #region Cashing Panel

    #endregion

    //Cash buy panel
    private bool CheckBuy(int requireMoney, int curMoney)
    {
        if (requireMoney <= curMoney)
        {
            return true; //allow buying
        }
        return false; //not allow to buy
    }
}
