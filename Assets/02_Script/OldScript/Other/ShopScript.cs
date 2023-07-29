using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTextScript : MonoBehaviour
{
    Text text;
    int shoppoint;
	// Use this for initialization
	void Start ()
    {
        shoppoint = Lv1Controller.cointAmount;
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        text.text = shoppoint.ToString();
    }
}
