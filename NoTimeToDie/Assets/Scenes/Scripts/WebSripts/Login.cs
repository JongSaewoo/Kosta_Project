using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField User_idInput;
    public InputField PasswordInput;
    public Button Login_button;
    public Button Register_button;
    [Space]
    public GameObject RegisterPanel;
    public GameObject LoginPanel;

    void Start()
    {
        // 로그인 사용자 데이터에 대한 이벤트 처리
        Login_button.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.Login(User_idInput.text, PasswordInput.text));

            //Welcom_settingPanel.SetActive(true);
            //LoginPanel.SetActive(false);
        });

        Register_button.onClick.AddListener(() =>
        {
            RegisterPanel.SetActive(true);
            LoginPanel.SetActive(false);
        });
    }
}
/* 참고!!
IEnumerator Login()
{
    form = new WWWForm();

    form.AddField("username", username.text);
    form.AddField("password", password.text);

    WWW w = new WWW(url, form);
    yield return w;

    if (w.error != null)
    {
        errorMessages.text = "404 not found!";
        Debug.Log("<color=red>" + w.text + "</color>");//error
    }
    else
    {
        if (w.isDone)
        {
            if (w.text.Contains("error"))
            {
                errorMessages.text = "invalid username or password!";
                Debug.Log("<color=red>" + w.text + "</color>");//error
            }
            else
            {
                //open welcom panel
                welcomePanel.SetActive(true);
                user.text = username.text;
                Debug.Log("<color=green>" + w.text + "</color>");//user exist
            }
        }
    }

    loginButton.interactable = true;
    progressCircle.SetActive(false);

    w.Dispose();
}
*/