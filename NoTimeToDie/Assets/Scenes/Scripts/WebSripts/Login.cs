using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField UserIdInput;
    public InputField PasswordInput;
    public Button LoginButton;


    void Start()
    {
        LoginButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.Login(UserIdInput.text, PasswordInput.text));
        });
    }
}
