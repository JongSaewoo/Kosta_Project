using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("bullet_head"))
        // bullet_head Tag를 적용했을 경우 정의
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            // 0번째 씬을 불러온다.
        }
    }
}
