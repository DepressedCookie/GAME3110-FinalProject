﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NetworkMessages;
using UnityEngine.SceneManagement;

public class Script_Login : MonoBehaviour
{
    HTTPClient http;

    [SerializeField] string GameMapName;
    [SerializeField] Text UsernameText;
    [SerializeField] Text PasswordText;
    // Start is called before the first frame update
    void Start()
    {
        http = GetComponent<HTTPClient>();
    }


    public void LoginButton()
    {
        http.Login(UsernameText.text, PasswordText.text);
    }

    public void LogedIn()
    {
        if (http.loginUser != null)
        {
            Debug.Log("You have loged in as: " + http.loginUser.user_id);
            FindMatch();
        }
    }

    public void LogInEvent(LoginMsg login)
    {
        Debug.Log(login.msg);
        switch (login.code)
        {
            // Failed to login
            case "0":

                break;

            // Wrong password
            case "1":

                break;

            // User created
            case "2":
                FindMatch();
                break;

            // Failed to create user
            case "3":

                break;
        }
    }

    void FindMatch()
    {
        SceneManager.LoadScene(GameMapName);
    }
}