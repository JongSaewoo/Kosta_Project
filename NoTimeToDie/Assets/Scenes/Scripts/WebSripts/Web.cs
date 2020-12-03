using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GetDate());
        //StartCoroutine(GetUsers());

        // user_name, user_password 입력
        //StartCoroutine(Login("JongWoo", "1234"));

        //StartCoroutine(ResisterUser("SeongMin", "123456"));
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
                // GetUsers.php에서 출력한 데이터의 결과 텍스트 값을 가져옴 
                Debug.Log(www.downloadHandler.text);

                byte[] results = www.downloadHandler.data;
            }
        }
    }

    public IEnumerator Login(string user_id, string user_password)
    {
        WWWForm form = new WWWForm();
        // Login.php에서 $loginUser와 $loginPass에 
        // Post한 값을 Get : 'loginUser' 
        form.AddField("loginUser", user_id);
        form.AddField("loginPass", user_password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityStartLogin/Login.php", form))
        {
            yield return www.SendWebRequest();

            // 에러 페이지
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Login.php에서 출력한 데이터 값
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator ResisterUser(string user_id, string user_name, string user_password, string user_confirmPass)
    {
        WWWForm form = new WWWForm();

        form.AddField("loginUser", user_id);
        form.AddField("loginName", user_name);
        form.AddField("loginPass", user_password);
        form.AddField("confirmPass", user_confirmPass);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityStartLogin/RegisterUser.php", form))
        {
            yield return www.SendWebRequest();

            // 에러 페이지
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Login.php에서 출력한 데이터 값
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
