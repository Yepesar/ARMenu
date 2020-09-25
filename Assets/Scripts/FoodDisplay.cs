using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class FoodDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI foodTitle;
    [SerializeField] private TextMeshProUGUI foodDescription;
    [SerializeField] private TextMeshProUGUI foodPrice;
    [SerializeField] private SO_Food[] foodInfos;
    [SerializeField] private Transform foodModels;

    private int index = 0;

    private void Start()
    {
        Display();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Next();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Prev();
        }
    }

    public void Next()
    {
        index++;
        if (index >= foodInfos.Length)
        {
            index = 0;
        }

        Display();
    }

    public void Prev()
    {
        index--;
        if (index < 0)
        {
            index = foodInfos.Length - 1;
        }

        Display();
    }

    private void Display()
    {
        for (int i = 0; i < foodModels.childCount; i++)
        {
            if (i == index)
            {
                foodModels.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                foodModels.GetChild(i).gameObject.SetActive(false);
            }
        }

        foodTitle.text = foodInfos[index].foodName;
        foodDescription.text = foodInfos[index].foodDescription;
        foodPrice.text = foodInfos[index].foodPrice + "";
    }
}
