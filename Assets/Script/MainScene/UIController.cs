using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject menu, optionPanel, shipediaPanel;

    private void Start()
    {
        OnDissbleAllUIs();
        showMenu(true);
    }

    #region Handle backend active
    private void showMenu(bool show) => menu.SetActive(show);
    private void showGame() => SceneManager.LoadScene("Playground");
    private void showOption(bool show) => optionPanel.SetActive(show);
    private void showShipedia(bool show) => shipediaPanel.SetActive(show);

    private void OnDissbleAllUIs()
    {
        showMenu(false);
        showOption(false);
        showShipedia(false);
    }
    #endregion

    #region Handle UIs interactive
    public void OnShowgame() => showGame();
    public void OnShowShiperdia() => showShipedia(true);
    public void OnShowMenu()
    {
        showOption(false);
        showMenu(true);
        showShipedia(false);
    }

    public void OnShowOption() => showOption(true);


    public void OnClosePanelOption() =>    showOption(false);
    public void OnCloseShipedia() => showShipedia(false);

    public void OnClickQuit() => Application.Quit();
    #endregion
}
