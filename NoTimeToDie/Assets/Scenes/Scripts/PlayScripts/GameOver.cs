using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //public UnityLoginLogoutRegister unityloginlogoutregister;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("bullet_head"))
        // bullet_head Tag를 적용했을 경우 정의
        {
            //unityloginlogoutregister.PlayButton.SetActive(false);
            //unityloginlogoutregister.ReplayButton.SetActive(true);
            SceneManager.LoadSceneAsync("AccountLogout");
        }
    }
}
