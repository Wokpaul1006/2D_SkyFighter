using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour {

    Image Bosshealthbar;
    float MaxHP = 1000f;
    public static float health;
    void Start()
    {
        Bosshealthbar = GetComponent<Image>();
        health = MaxHP;
    }
    void Update()
    {
        Bosshealthbar.fillAmount = health / MaxHP;
    }
}
