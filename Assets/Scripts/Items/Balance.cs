using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Balance : MonoBehaviour
{
    private string nameUser;
    public float balance;
    TextMeshProUGUI textMeshProUGUI;
    private void Start()
    {
        textMeshProUGUI = gameObject.GetComponent<TextMeshProUGUI>();
        nameUser = DBManager._DB_MANAGER.GetUserName(GameManager._GAMEMANAGER.userID);
        balance = DBManager._DB_MANAGER.GetPlayerBalance(GameManager._GAMEMANAGER.userID);
    }

    private void Update()
    {
        textMeshProUGUI.text = nameUser + ": " + balance.ToString() + "$";
    }
    public void RestBalance(int number)
    {
        balance -= number;
    }
    public void SetBalanceDB()
    {
        DBManager._DB_MANAGER.SetPlayerBalance(GameManager._GAMEMANAGER.userID, balance);
    }
    public void SetBalanceForWin(int blc)
    {
        balance += blc;
    }
}
