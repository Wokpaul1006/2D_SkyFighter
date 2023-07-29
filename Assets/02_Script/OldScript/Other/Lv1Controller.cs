using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lv1Controller : MonoBehaviour
{
    Text text;
    public static int cointAmount;
    void Start()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {
        text.text = cointAmount.ToString();
    }
}
