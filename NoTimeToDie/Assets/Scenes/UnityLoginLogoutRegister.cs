using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class UnityLoginLogoutRegister : MonoBehaviour
{

    public string baseUrl = "http://localhost/UnityUserLog/";


    public InputField accountUserName;
    public InputField accountPassword;
    public Text info;

    private string currentUsername;
    private string ukey = "accountusername";

    void Start()
    {
        currentUsername = "";

        // 다른 씬으로 이동 혹은 로그인 prefab이 SetActive(false)가 되도 데이터를 잃지 않기 위해 
        // "PlayerPrefs : using UnityEngin - 데이터 관리 클래스" 를 사용
        if (PlayerPrefs.HasKey(ukey))
        {
            if (PlayerPrefs.GetString(ukey) != "")
            {
                currentUsername = PlayerPrefs.GetString(ukey);
                info.text = "'" + currentUsername + "' 님 반갑습니다." ;
            }
            else
            {
                info.text = "현재 로그인 정보가 없습니다.";
            }
        }
        else
        {
            info.text = "You are not loged in.";
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AccountLogout()
    {
        currentUsername = "";
        PlayerPrefs.SetString(ukey, currentUsername);
        info.text = "You are just loged out.";
    }

    public void AccountRegister()
    {
        string uName = accountUserName.text;
        string pWord = accountPassword.text;
        StartCoroutine(RegisterNewAccount(uName, pWord));
    }

    public void AccountLogin()
    {
        string uName = accountUserName.text;
        string pWord = accountPassword.text;
        StartCoroutine(LogInAccount(uName, pWord));
    }

    IEnumerator RegisterNewAccount(string uName, string pWord)
    {
        WWWForm form = new WWWForm();
        form.AddField("newAccountUsername", uName);
        form.AddField("newAccountPassword", pWord);
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
                Debug.Log("Response = " + responseText);
                info.text = "Response = " + responseText;
            }
        }
    }

    IEnumerator LogInAccount(string uName, string pWord)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUsername", uName);
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
                    PlayerPrefs.SetString(ukey, uName);
                    //info.text = "Login Success with username " + uName;
                    SceneManager.LoadSceneAsync("007NoTimeToDie");
                }
                else
                {
                    info.text = "Login Failed.";
                }
            }
        }
    }
}