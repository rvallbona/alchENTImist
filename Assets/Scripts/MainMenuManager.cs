using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    #region Variables
    [Header("Canvas")]
    [SerializeField] GameObject canvasLoggin, canvasMainMenu, canvasInGame, canvasOptions, canvasCredits, canvasRecipies, canvasWin;
    [SerializeField] Potions potion;
    #endregion
    private void Update()
    {
        CheckWin();
    }
    #region ChangeCanvas
    public void ChangeInGameCanvas()
    {
        canvasInGame.SetActive(true);
        canvasMainMenu.SetActive(false);
    }
    public void ChangeOptionCanvas()
    {
        canvasOptions.SetActive(true);
        canvasMainMenu.SetActive(false);
    }
    public void ChangeCreditsCanvas()
    {
        canvasCredits.SetActive(true);
        canvasMainMenu.SetActive(false);
    }
    public void ChangeRecipiesCanvas()
    {
        canvasRecipies.SetActive(true);
        canvasInGame.SetActive(false);
    }
    public void ChangeWinCanvas()
    {
        canvasWin.SetActive(true);
        canvasInGame.SetActive(false);
    }
    #endregion
    #region BackFunctions
    public void BackRecipies()
    {
        canvasRecipies.SetActive(false);
        canvasInGame.SetActive(true);
    }
    public void BackOptions()
    {
        canvasOptions.SetActive(false);
        canvasMainMenu.SetActive(true);
    }
    public void BackCredits()
    {
        canvasCredits.SetActive(false);
        canvasMainMenu.SetActive(true);
    }
    #endregion
    #region OtherFunctions
    public void Logged()
    {
        canvasLoggin.SetActive(false);
        canvasMainMenu.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    #endregion
    #region CheckWin
    void CheckWin()
    {
        if (potion.indexWin >= 4)
        {
            ChangeWinCanvas();
        }
    }
    #endregion
}