using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public InputField User_idInput;
    public InputField User_nameInput;
    public InputField PasswordInput;
    public InputField Confirm_passInput;
    public Button SubmitButton;
    public Button BackButton;

    void Start()
    {
        // 회원가입 데이터 제출에 대한 이벤트 처리
        SubmitButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.ResisterUser(User_idInput.text, User_nameInput.text, PasswordInput.text, Confirm_passInput.text));
            //LoginPanel.SetActive(true);
            //RegisterPanel.SetActive(false);
        });

        BackButton.onClick.AddListener(() =>
        {
            //LoginPanel.SetActive(true);
            //RegisterPanel.SetActive(false);
        });
    }

    // NullPointException 처리 : Web클래스가 상속받을 수 있도록함.
    public void NullException()
    {

    }
}
