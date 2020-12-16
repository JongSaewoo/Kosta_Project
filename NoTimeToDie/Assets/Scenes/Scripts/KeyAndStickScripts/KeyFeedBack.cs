using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFeedBack : MonoBehaviour
{
    private KeySoundHandler keySoundHandler;    // KeySoundHandler클래스에서 audio source를 가져와 Tag를 이용하여 객체 생성

    public bool keyHit = false;
    public bool keyCanBeHitAgain = false;

    private float originalYPosition;

    void Start()
    {
        // Tag 사용
        keySoundHandler = GameObject.FindGameObjectWithTag("KeySoundHandler").GetComponent<KeySoundHandler>();

        originalYPosition = transform.position.y;
    }

    void Update()
    {
        // keyPress시 키가 눌리는 애니메이션 구현
        if(keyHit)
        {
            keySoundHandler.PlayKeyClick();
            keyCanBeHitAgain = false;
            keyHit = false;
            transform.position += new Vector3(0, -0.03f, 0);
        }

        // 키가 눌린 상태에서 회복되는 애니메이션 구현 
        if(transform.position.y < originalYPosition)
        {
            transform.position += new Vector3(0, 0.005f, 0);
        }
        else  // 회복이 완료되면 다시 키를 누를 수 있음을 알림(알림역할o, 기능역할x)
        {
            keyCanBeHitAgain = true;
        }
    }
}
