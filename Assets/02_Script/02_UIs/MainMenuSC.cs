using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSC : MonoBehaviour
{
    private OmniMN omniMN;
    private void Start()
    {
        omniMN = GameObject.Find("OmniMN").GetComponent<OmniMN>();
    }
    public void OnButtonCommand()
    {
        if (gameObject.name == "PlayStoryBtn")
        {
            omniMN.OnChangeScene(1);
        }
        else if (gameObject.name == "PlayArenaBtn")
        {
            omniMN.OnChangeScene(2);
        }
        else if (gameObject.name == "PlayPvP")
        {
            omniMN.OnChangeScene(3); 
        }
        else if (gameObject.name == "???")
        {
            omniMN.OnChangeScene(4);
        }
        else if (gameObject.name == "ExitBtn") 
        {
            omniMN.OnChangeScene(5);
        }
        else if (gameObject.name == "OptionBtn")
        {

        }
        else if (gameObject.name == "ShopBtn")
        {

        }
        else if (gameObject.name == "AchivemnetBtn")
        {

        }
        else if (gameObject.name == "CreditBtn")
        {

        }
        else if (gameObject.name == "Leaderboard")
        {

        }
        else if (gameObject.name == "DailyPatrol")
        {

        }
    }
}
