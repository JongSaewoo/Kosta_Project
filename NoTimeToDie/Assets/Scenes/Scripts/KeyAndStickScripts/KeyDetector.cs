using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyDetector : MonoBehaviour
{
    private TextMeshPro playerTextOutput;   // 키 타이핑 텍스트박스

    void Start()
    {
        // Tag 사용
        playerTextOutput = GameObject.FindGameObjectWithTag("PlayerTextOutput").GetComponent<TextMeshPro>();
    }

    private void OntriggerEnter(Collider other)
    {
        var key = other.GetComponentInChildren<TextMeshPro>();

        if(other.gameObject.GetComponent<KeyFeedBack>().keyCanBeHitAgain)
        {
            // Space
            if(key.text == "Space")
            {
                playerTextOutput.text += " ";
            }
            // Backspace 
            else if(key.text == "Backspace")
            {
                playerTextOutput.text = playerTextOutput.text.Substring(0, playerTextOutput.text.Length - 1);
            }
            // Shift, Enter도 구현해보기!

            // 일반 key
            else
            {
                playerTextOutput.text += key.text;
            }
        }
    }
}
