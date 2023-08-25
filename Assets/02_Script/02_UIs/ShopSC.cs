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
    private void UpdateCoinText(int valueToUpdate) => coinText.text = valueToUpdate.ToString();
    #region Enemies Panel
    public void OnBuyPerShot()
    {
        int price = 100;
        if(CheckBuyForEnemy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurEnemies", 1);
        }
    }
    public void OnBuyDualShot()
    {
        int price = 200;
        if (CheckBuyForEnemy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurEnemies", 2);
        }
    }
    public void OnBuyConeShot()
    {
        int price = 400;
        if (CheckBuyForEnemy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurEnemies", 3);
        }
    }
    public void OnBuyBouncer()
    {
        int price = 800;
        if (CheckBuyForEnemy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurEnemies", 4);
        }
    }
    public void OnBuyRandompath()
    {
        int price = 1600;
        if (CheckBuyForEnemy(price, curCoinForPurchase))
        {
            curCoinForPurchase -= curCoinForPurchase - price;
            UpdateCoinText(curCoinForPurchase);
            PlayerPrefs.SetInt("CurEnemies", 5);
        }
    }
    public void OnBuyChronoshift()
    {
        int price = 3200;
        if (CheckBuyForEnemy(price, curCoinForPurchase))
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

    }
    public void OnBuyTripleBullet()
    {

    }
    public void OnBuyAOEMissle()
    {

    }
    public void OnBuyInlineMissle()
    {


    }
    public void OnBuyProtectShile()
    {

    }
    public void OnBuyRoundMissle()
    {

    }
    public void OnBuyFreezingTime()
    {

    }
    public void OnBuyFanlikeWarhead()
    {

    }
    #endregion

    //Cash buy panel

    private bool CheckBuyForEnemy(int coditionMoney, int curMoney)
    {
        if(coditionMoney <= curMoney)
        {
            return true; //allow buying
        }
        return false; //not allow to buy
    }
}
