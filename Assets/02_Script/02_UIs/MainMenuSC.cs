using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSC : MonoBehaviour
{
    public List<GameObject> panels = new List<GameObject>();
    private OmniMN omniMN;
    private PanelsMN panelsMN = new PanelsMN();

    private string panelName;
    private void Start()
    {
        omniMN = GameObject.Find("OmniManager").GetComponent<OmniMN>();
    }

    #region Switch Scene & Panels
    public void OnToStorymode() =>  omniMN.OnChangeScene(1);
    public void OnToArena() => omniMN.OnChangeScene(2);
    public void OnToPvP() => omniMN.OnChangeScene(3);
    public void OnToMOBA() => omniMN.OnChangeScene(4);
    public void OnExit() => omniMN.OnChangeScene(5);
    public void OnToShop() { }
    public void OnToOption() { }
    public void OnToAchivement() { }
    public void OnToCredit() { }
    public void OnToLeaderboard() { }
    public void OnToInfo() { }
    public void OnToPartrolEarning() { }
    public void OnToNews() { }
    #endregion

    #region Panel Define
    
    #endregion
}
