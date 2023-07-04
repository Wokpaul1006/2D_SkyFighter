using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmoryController : MonoBehaviour
{
    int isshipsold;
    public GameObject Battlecruiser;
    public GameObject Viking;
	// Use this for initialization
	void Start ()
    {
        isshipsold = PlayerPrefs.GetInt("IsShipSold");
        if (isshipsold == 1)
        {
            Viking.SetActive(true);
        }
        else Viking.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
