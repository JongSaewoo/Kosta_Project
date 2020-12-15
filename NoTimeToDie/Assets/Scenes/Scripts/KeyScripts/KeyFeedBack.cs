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
        keySoundHandler = GameObject.FindGameObjectWithTag("KeySoundHandler").GetComponent<KeySoundHandler>();
        originalYPosition = transform.position.y;
    }

    void Update()
    {
        // keyPress시 애니메이션 구현
        if(keyHit = true)
        {
            keySoundHandler.PlayKeyClick();
            keyCanBeHitAgain = false;
            keyHit = false;
            transform.position += new Vector3(0, -0.03f, 0);
        }
        if(transform.position.y < originalYPosition)
        {
            transform.position += new Vector3(0, 0.005f, 0);
        }
        else
        {
            keyCanBeHitAgain = true;
        }
    }
}
