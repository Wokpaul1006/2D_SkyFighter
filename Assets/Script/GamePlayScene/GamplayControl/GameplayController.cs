using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : Singleton<GameplayController>
{
    #region Clarify ingame object
    [SerializeField] PlayerSript player;
    [SerializeField] OptionPanel optPanel;
    [SerializeField] SpawnerSC spawn;
    #endregion

    #region Clarify UIs object
    [SerializeField] HPBar hp;
    #endregion

    #region Declare element var for UI
    public float gpHP, gpAP, gpExp;
    public int gpLevel;
    #endregion

    void Start()
    {
        gpLevel = 4; //Min = 1; Max = ?
        SpawnPlayer();
        OnCheckLevel(gpLevel);
        ShowOptionPanel(false);
        hp.OnStartGame();
    }

    private void LateUpdate()
    {
        if (gpExp == gpLevel * 10)
        {
            gpLevel++;
            gpExp = 0;
            OnCheckLevel(gpLevel);
        }
    }

    #region Handle gameplay activity
    private void SpawnPlayer() => Instantiate(player, Vector3.zero, Quaternion.identity);
    private void OnCheckLevel(int inputLvl)
    {
        if(inputLvl > 8)
        {
            spawn.CancelInvoke("SpawnChrono");
            spawn.SpawnKamikaze();
            spawn.SpawnPerShot();
            spawn.SpawnDualShot();
            spawn.SpawnConeShot();
            spawn.SpawnDiagonal();
            spawn.SpawnRandom();
            spawn.SpawnChrono();
        }
        else
        {
            switch (inputLvl)
            {
                case 1:
                    spawn.SpawnKamikaze();
                    break;
                case 2:
                    spawn.CancelInvoke("SpawnKamikaze");
                    spawn.SpawnPerShot();
                    break;
                case 3:
                    spawn.CancelInvoke("SpawnPerShot");
                    spawn.SpawnDualShot();
                    break;
                case 4:
                    spawn.CancelInvoke("SpawnDualShot");
                    spawn.SpawnConeShot();
                    break;
                case 5:
                    spawn.CancelInvoke("SpawnConeShot");
                    spawn.SpawnDiagonal();
                    break;
                case 6:
                    spawn.CancelInvoke("SpawnDiagonal");
                    spawn.SpawnRandom();
                    break;
                case 7:
                    spawn.CancelInvoke("SpawnRandom");
                    spawn.SpawnChrono();
                    break;
            }
        }
    }
    public void ShowOptionPanel(bool show)
    {
        optPanel.gameObject.SetActive(show);
    }

    #endregion

    #region Handle UIs Interactive
    public void OnShowOption()
    {
        optPanel.gameObject.SetActive(true);
    }
    public void OnDownHPUIs(float healthToMinus)
    {
        print("in UIs controller: " + healthToMinus);
        print("gpHP before caculatin: " + gpHP);
        gpHP -= healthToMinus;
        print("gpHP after caculatin: "+gpHP);
        //hp.OnHPDecrease(healthToMinus);
    }
    #endregion
}
