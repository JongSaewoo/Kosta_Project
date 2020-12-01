using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetDate());
        StartCoroutine(GetUsers());
    }

    // GetDate 데이터 파일
    IEnumerator GetDate()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/UnityStartLogin/GetDate.php")) 
        {
            yield return www.Send();

            // 에러 페이지
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // 결과 텍스트를 보여줌
                Debug.Log(www.downloadHandler.text);
               
                byte[] results = www.downloadHandler.data;
            }


        }
    }

    // GetUsers 데이터 파일
    IEnumerator GetUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/UnityStartLogin/GetUsers.php"))
        {
            yield return www.Send();

            // 에러 페이지
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // 결과 텍스트를 보여줌
                Debug.Log(www.downloadHandler.text);

                byte[] results = www.downloadHandler.data;
            }


        }
    }


}
