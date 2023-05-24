using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegisterControl : MonoBehaviour
{
    [Header("Register")]
    public TMP_InputField usernameInput;
    private string user_name;
    List<string> nameUsersList;

    [SerializeField] MainMenuControl menuControl;
    void Update()
    {
        user_name = usernameInput.text;
    }
    public void RegisterButtonClick()
    {
        if (user_name != "")
        {
            DBManager._DB_MANAGER.CreateUser(user_name);
            DoLoggin();
        }
    }
    void DoLoggin()
    {      
        menuControl.Logged();
    }
}
