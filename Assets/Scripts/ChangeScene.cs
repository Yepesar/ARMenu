using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private float delay = 2f;
    [SerializeField] private Animator fade;

    private int index = 0;

    public void LoadScene(int scene_index)
    {
        index = scene_index;
        fade.SetBool("FadeIn", true);
        Invoke("Load", delay);
    }

    private void Load()
    {
        SceneManager.LoadSceneAsync(index);
    }
}
