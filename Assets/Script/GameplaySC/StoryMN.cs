using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryMN : MonoBehaviour
{
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] DataSC data;
    [HideInInspector] PlayerSC player;

    [SerializeField] Text hpAmountTxt, ammoAmountTxt, manaTxt;
    [SerializeField] Image hpFillImh, ammoFillImg, manaFillImh;
    
    private int hpAmount, ammoAmount, manaAmount;

    private void Start()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        data = GameObject.Find("OBJ_DataCtr").GetComponent<DataSC>();

        GetPlayerInfor();
    }
    private void GetPlayerInfor()
    {
        print("Player Class = " + data.playerClass);
    }
    private void OnUpdatePlayerUIs()
    {

    }
}
