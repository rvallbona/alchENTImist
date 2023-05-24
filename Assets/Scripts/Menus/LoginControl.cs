using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoginControl : MonoBehaviour
{
    [Header("Loggin")]
    public TMP_InputField usernameInput;
    private string user_name;
    List<string> nameUsersList;

    [SerializeField] MainMenuControl menuControl;
    void Start()
    {
        user_name = usernameInput.text;
    }
    void Update()
    {
        user_name = usernameInput.text;
        nameUsersList = DBManager._DB_MANAGER.GetLoginNameList();
        for (int i = 0; i < nameUsersList.Count; i++)
        {
            if (nameUsersList[i] == user_name)
            {
                menuControl.Logged();
                Destroy(gameObject);
            }
        }
    }

}