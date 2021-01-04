using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("bullet"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            //SceneManager.LoadSceneAsync("Login");
        }
    }
}
