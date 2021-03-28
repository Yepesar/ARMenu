using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogleObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] objs;
    [SerializeField] private GameObject togleOnButton;
    [SerializeField] private GameObject togleOffButton;

    public void Togle(bool on)
    {
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].SetActive(on);
        }

        if (on)
        {
            togleOffButton.SetActive(true);
            togleOnButton.SetActive(false);
        }
        else
        {
            togleOffButton.SetActive(false);
            togleOnButton.SetActive(true);
        }
    }
}
