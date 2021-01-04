using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WelcomSetting : MonoBehaviour
{
    public InputField PasswordInput;
    public Button PlayButton;
    public Button LogoutButton;
    [Space]
    public GameObject LoginPanel;
    public GameObject Welcom_settingPanel;

    void Start()
    {
        PlayButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });

        LogoutButton.onClick.AddListener(() =>
        {
            //LoginPanel.SetActive(true);
            //Welcom_settingPanel.SetActive(false);
        });
    }

}
