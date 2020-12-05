using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public static Main Instance;

    public Web Web;

    void Start()
    {
        Instance = this;
        Web = GetComponent<Web>();
    }
}
