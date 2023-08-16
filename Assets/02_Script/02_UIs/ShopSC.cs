using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSC : MonoBehaviour
{
    //Enemy panel
    public void OnBuyPerShot()
    {
        PlayerPrefs.SetInt("CurEnemies", 1);
    }
    public void OnBuyDualShot()
    {
        PlayerPrefs.SetInt("CurEnemies", 2);
    }
    public void OnBuyConeShot()
    {
        PlayerPrefs.SetInt("CurEnemies", 3);
    }
    public void OnBuyBouncer()
    {
        PlayerPrefs.SetInt("CurEnemies", 4);
    }
    public void OnBuyRandompath()
    {
        PlayerPrefs.SetInt("CurEnemies", 5);
    }
    public void OnBuyChronoshift()
    {
        PlayerPrefs.SetInt("CurEnemies", 6);
    }

    //Player buy panel


    //Cash buy panel
}
