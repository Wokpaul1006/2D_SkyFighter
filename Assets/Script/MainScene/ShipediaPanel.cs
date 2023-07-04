using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipediaPanel : MonoBehaviour
{
    [SerializeField] GameObject Detailpanel;
    [SerializeField] Text shipNameTxt, shipSpdTxt, shipAtkTxt, shipDesTxt;
    private string shipDes;

    void Start()
    {
        ShowDetailPnl(false);
    }
    private void ShowDetailPnl(bool show)
    {
        Detailpanel.SetActive(show);
    }

    private void ShowDetailText(string name, int atk, int spd, string des)
    {
        shipNameTxt.text = name;
        shipAtkTxt.text = atk.ToString();
        shipSpdTxt.text = spd.ToString();
        shipDesTxt.text = des;
    }

    #region Handle on click button
    public void onClickClosePnl()
    {
        ShowDetailPnl(false);
    }
    public void onClickKamikaze()
    {
        ShipDes("Kamikaze");
        ShowDetailPnl(true);
        ShowDetailText("Kamikaze", 0, 7,shipDes);
    }
    public void onClickPershot()
    {
        ShipDes("Pershot");
        ShowDetailPnl(true);
        ShowDetailText("Pershot", 0, 5,shipDes);
    }
    public void onClickDualShot()
    {
        ShipDes("DualShot");
        ShowDetailPnl(true);
        ShowDetailText("DualShot", 0, 5,shipDes);
    }
    public void onClickConeShot()
    {
        ShipDes("ConeShot");
        ShowDetailPnl(true);
        ShowDetailText("ConeShot", 0, 5,shipDes );
    }
    public void onClickBouncer()
    {
        ShipDes("Bouncer");
        ShowDetailPnl(true);
        ShowDetailText("Bouncer", 0, 5,shipDes);
    }
    public void onClickChrono()
    {
        ShipDes("Chrono");
        ShowDetailPnl(true);
        ShowDetailText("Chrono", 0, 5, shipDes);
    }
    public void onClickUnexpecter()
    {
        ShipDes("Unexpecter");
        ShowDetailPnl(true);
        ShowDetailText("Unexpecter", 0, 5, shipDes);
    }
    #endregion

    private void ShipDes(string shipname)
    {
        switch (shipname)
        {
            case "Kamikaze":
                shipDes = "This ship isn't shot anything";
                break;
            case "Pershot":
                shipDes = "This ship shot one bullet at a time";
                break;
            case "DualShot":
                shipDes = "This ship shot two bullet at a time";
                break;
            case "ConeShot":
                shipDes = "This ship shot three bullet at a time";
                break;
            case "Bouncer":
                shipDes = "This ship bouncing throght scree";
                break;
            case "Chrono":
                shipDes = "This ship chrono througt srceen";
                break;
            case "Unexpecter":
                shipDes = "This ship random caculating route";
                break;
        }
    }
}
