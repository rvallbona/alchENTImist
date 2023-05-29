using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _GAMEMANAGER;

    public int userID = 1;

    private string userName = "Player";
    public float balance = 0f;
    private int currentQuest = 1;

    private void Awake()
    {
        if (_GAMEMANAGER != null && _GAMEMANAGER != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _GAMEMANAGER = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public int GetUserID()
    {
        return userID;
    }

    public void SetUserID(int newId)
    {
        userID = newId;
    }

    public void InitUserInfo()
    {
        userName = DBManager._DB_MANAGER.GetUserName(userID);
        balance = DBManager._DB_MANAGER.GetPlayerBalance(userID);
        currentQuest = DBManager._DB_MANAGER.GetPlayerLvl(userID);
    }

    public string GetUserName()
    {
        return userName;
    }
    public void SetUserName(string name)
    {
        userName = name;
    }

    public float GetBalance()
    {
        return balance;
    }

    public void UpdateBalance(float difference = 0f)
    {
        balance = DBManager._DB_MANAGER.GetPlayerBalance(userID);
        balance += difference;
        DBManager._DB_MANAGER.SetPlayerBalance(userID, balance);
    }

    public int GetCurrentQuest()
    {
        return currentQuest;
    }

    public void SetCurrentQuest(int newQuest)
    {
        currentQuest = newQuest;
    }
}
