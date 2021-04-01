using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogleObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] descriptionObjs;
    [SerializeField] private GameObject[] imgObjs;

    [SerializeField] private GameObject togleOnButton;
    [SerializeField] private GameObject togleOffButton;

    public void Togle(bool on)
    {
        for (int i = 0; i < descriptionObjs.Length; i++)
        {
            descriptionObjs[i].SetActive(on);
        }

        for (int i = 0; i < imgObjs.Length; i++)
        {
            imgObjs[i].SetActive(!on);
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
