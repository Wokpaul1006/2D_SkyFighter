using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] Slider hpbar;

    public void OnStartGame()
    {
        hpbar.value = 100f;
    }

    public void OnHPDecrease(float healthToMinus)
    {
        print("in HPBar, healthToMinus: " + healthToMinus);
        hpbar.value -= healthToMinus;
        if(hpbar.value < 0)
        {
            hpbar.value = 0;
        }
    }

    public void OnHPIncrease(float healthToPlus)
    {
        hpbar.value += healthToPlus;
        if(hpbar.value > 100)
        {
            hpbar.value = 100f;
        }
    }
}
