using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoginControl : MonoBehaviour
{
    #region Variables
    [Header("DB")]
    DBManager dbManager;

    [Header("Loggin")]
    public TMP_InputField usernameInput;
    private string user_name;
    List<string> nameUsersList;

    [SerializeField] MainMenuManager menuManager;
    #endregion
    void Start()
    {
        user_name = usernameInput.text;
        dbManager = GetComponent<DBManager>();
        dbManager = GameObject.FindGameObjectWithTag("dbManager").GetComponent<DBManager>();
    }
    void Update()
    {
        user_name = usernameInput.text;
        nameUsersList = dbManager.GetLoginNameList();
        for (int i = 0; i < nameUsersList.Count; i++)
        {
            if (nameUsersList[i] == user_name)
            {
                menuManager.Logged();
                Destroy(gameObject);
            }
        }
    }
}