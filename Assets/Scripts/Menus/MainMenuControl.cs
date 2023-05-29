using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuControl : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] GameObject canvasLoggin, canvasMainMenu, canvasInGame, canvasOptions, canvasCredits, canvasRecipies, canvasWin, canvasRegister;
    private void Update()
    {
        //CheckWin();
    }
    public void ChangeInGameCanvas()
    {
        canvasInGame.SetActive(true);
        canvasMainMenu.SetActive(false);
    }
    public void ChangeRegisterCanvas()
    {
        canvasRegister.SetActive(true);
        canvasLoggin.SetActive(false);
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
    public void BackLoggin()
    {
        canvasRegister.SetActive(false);
        canvasLoggin.SetActive(true);
    }
    public void Logged()
    {
        canvasLoggin.SetActive(false);
        canvasMainMenu.SetActive(true);
    }
    public void Registred()
    {
        canvasLoggin.SetActive(false);
        canvasRegister.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    void CheckWin()
    {
        ChangeWinCanvas();
    }
}