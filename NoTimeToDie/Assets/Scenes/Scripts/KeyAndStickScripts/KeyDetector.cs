using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyDetector : MonoBehaviour
{
    private TextMeshPro playerTextOutput;   // 타이핑값이 출력 될 텍스트박스

    void Start()
    {
        // Tag 사용
        playerTextOutput = GameObject.FindGameObjectWithTag("PlayerTextOutput").GetComponentInChildren<TextMeshPro>();
    }

    // Collider 발생시
    private void OntriggerEnter(Collider other)
    {
        var key = other.GetComponentInChildren<TextMeshPro>();

        if (key != null)
        {
            // KeyFeedBack 클래스에서 keyHit 컴포넌트 가져오기
            var keyFeedBack = other.gameObject.GetComponent<KeyFeedBack>();

            if (keyFeedBack.keyCanBeHitAgain)
            {
                // Space
                if (key.text == "Space")
                {
                    playerTextOutput.text += " ";
                }
                // Backspace 
                else if (key.text == "Backspace")
                {
                    playerTextOutput.text = playerTextOutput.text.Substring(0, playerTextOutput.text.Length - 1);
                }
                // Shift, Enter, .com, @도 구현해보기!

                // 일반 key
                else
                {
                    playerTextOutput.text += key.text;
                }

                keyFeedBack.keyHit = true;
            }
        }
    }
}
