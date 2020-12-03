using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public InputField UserIdInput;
    public InputField UsernameInput;
    public InputField PasswordInput;
    public InputField ConfirmPassInput;
    public Button SubmitButton;
    public Button BackButton;

    void Start()
    {
        SubmitButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.ResisterUser(UserIdInput.text, UsernameInput.text, PasswordInput.text, ConfirmPassInput.text));
        });

        BackButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.ResisterUser(UserIdInput.text, UsernameInput.text, PasswordInput.text, ConfirmPassInput.text));
        });
    }
}
