using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSC : MonoBehaviour
{
    [SerializeField] Text panelName;
    public List<GameObject> panels = new List<GameObject>();
    private OmniMN omniMN;
    private PanelsMN panelsMN = new PanelsMN();
    private void Start()
    {
        omniMN = GameObject.Find("OmniManager").GetComponent<OmniMN>();
        ToHome();
    }

    private void ClearAllPanels()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].gameObject.SetActive(false);
        }
    }
    #region Switch Scene & Panels
    public void OnToStorymode() =>  omniMN.OnChangeScene(1);
    public void OnToArena() => omniMN.OnChangeScene(2);
    public void OnToPvP() => omniMN.OnChangeScene(3);
    public void OnToMOBA() => omniMN.OnChangeScene(4);
    public void OnExit() => omniMN.OnChangeScene(5);
    public void OnToOption() 
    {
        panelName.text = "OPTION";
        ClearAllPanels();
        panels[1].SetActive(true);
    }
    public void OnToShop()
    {
        panelName.text = "SHOP";
        ClearAllPanels();
        panels[2].SetActive(true);
    }
    public void OnToAchivement() 
    {
        panelName.text = "ACHIVEMENT";
        ClearAllPanels();
        panels[3].SetActive(true);
    }
    public void OnToCredit()
    {
        panelName.text = "CREDIT";
        ClearAllPanels();
        panels[4].SetActive(true);
    }
    public void OnToLeaderboard() 
    {
        panelName.text = "LEADERBOARD";
        ClearAllPanels();
        panels[5].SetActive(true);
    }
    public void OnToArmory() 
    {
        panelName.text = "INFORMATION";
        ClearAllPanels();
        panels[6].SetActive(true);
    }
    public void OnToPartrolEarning() 
    {
        panelName.text = "PATROL EARNING";
        ClearAllPanels();
        panels[7].SetActive(true);
    }
    public void OnToNews() 
    {
        panelName.text = "NEWS";
        ClearAllPanels();
        panels[8].SetActive(true);
    }
    public void OnUserInfor()
    {
        panelName.text = "USER INFOR";
        ClearAllPanels();
        panels[9].SetActive(true);
    }
    public void OnContact()
    {
        panelName.text = "CONTACT";
        ClearAllPanels();
        panels[10].SetActive(true);
    }
    public void ToHome()
    {
        panelName.text = "";
        ClearAllPanels();
        panels[0].SetActive(true);
    }
    #endregion

    #region Panel Define
    
    #endregion
}
