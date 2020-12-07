﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class UnityLoginLogoutRegister : MonoBehaviour
{
    public string baseUrl = "http://localhost/UnityUserLog/";

    public InputField accountUserID;
    public InputField accountUserName;
    public InputField accountUserEmail;
    public InputField accountPassword;
    public InputField accountPasswordCheck;
    public Text info;

    private string currentUsername; // 키 값을 담을 변수
    private string ukey = "";       // 키 값 초기화

    void Start()
    {
        currentUsername = "";

        // 다른 씬으로 이동 혹은 로그인 prefab이 SetActive(false)가 되도 데이터를 잃지 않기 위해 
        // "PlayerPrefs : using UnityEngin - 데이터 관리 클래스" 를 사용
        if (PlayerPrefs.HasKey(ukey))  // HasKey : 키의 존재 bool
        {
            if (PlayerPrefs.GetString(ukey) != "")  // GetString : 키의 값 load
            {
                currentUsername = PlayerPrefs.GetString(ukey);
                info.text = "'" + currentUsername + "' 님 반갑습니다.";
            }
            else
            {
                info.text = "로그인 정보를 입력해주세요.";
            }
        }
        else  // ukey = null
        {
            info.text = "ukey값이 존재하지 않습니다.";
            Debug.Log("ukey값이 존재하지 않습니다.");
        }
    }

    // LoginButton : Login -> Game
    public void AccountLogin()
    {
        string uID = accountUserID.text;
        string pWord = accountPassword.text;
        StartCoroutine(LogInAccount(uID, pWord));
        info.text = "'" + currentUsername + "' 님 환영합니다.";
    }

    // NewAccountButton : Login -> Register
    public void NewAccount()
    {
        SceneManager.LoadSceneAsync("AccountRegistration");
    }

    // LogoutButton : Logout -> Login
    public void AccountLogout()
    {
        currentUsername = "";
        PlayerPrefs.SetString(ukey, currentUsername);   // SetString : save -> ukey에 currentUsername=""을 넣음으로써 ukey값을 초기화
        info.text = "성공적으로 로그아웃하였습니다.";
    }

    // RegisterButton : Register -> Login
    public void AccountRegister()
    {
        string uID = accountUserID.text;
        string uName = accountUserName.text;
        string uEmail = accountUserEmail.text;
        string pWord = accountPassword.text;
        string CKpWord = accountPasswordCheck.text;
        StartCoroutine(RegisterNewAccount(uID, uName, uEmail, pWord, CKpWord));
        SceneManager.LoadSceneAsync("AccountLogin");
    }

    // Login Session
    IEnumerator LogInAccount(string uID, string pWord)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginID", uID);
        form.AddField("loginPassword", pWord);
        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;

                if (responseText == "1")   
                {
                    Debug.Log("Game Loading ...");
                    PlayerPrefs.SetString(ukey, uID);
                    SceneManager.LoadSceneAsync("007NoTimeToDie");
                }
                else
                {
                    Debug.Log(responseText);
                    info.text = responseText;
                }
            }
        }
    }

    // Register Session
    IEnumerator RegisterNewAccount(string uID, string uName, string uEmail, string pWord, string CKpWord)
    {
        WWWForm form = new WWWForm();
        form.AddField("newAccountID", uID);
        form.AddField("newAccountUsername", uName);
        form.AddField("newAccountEmail", uEmail);
        form.AddField("newAccountPassword", pWord);
        form.AddField("newAccountCheckPW", CKpWord);
        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            string responseText = www.downloadHandler.text;

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(responseText);
                info.text = responseText;

                SceneManager.LoadSceneAsync("AccountLogin");
            }
        }
    }
}