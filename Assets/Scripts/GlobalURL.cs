using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GlobalURL : MonoBehaviour
{
    public int index = 0;
    public int max;

    public static GlobalURL globalURL;

    private void Start()
    {
        if (!globalURL)
        {
            globalURL = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void GetCall(string url)
    {
        index++;
        if (index >= max)
        {
            index = 0;
            OpenURL(url);
        }
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}
