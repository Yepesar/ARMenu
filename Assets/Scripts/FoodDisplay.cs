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
    [SerializeField] private TMP_Dropdown categoryDropdown;
    [Space]
    [SerializeField] private SO_Food[] foodInfosCat1;
    [SerializeField] private SO_Food[] foodInfosCat2;
    [SerializeField] private SO_Food[] foodInfosCat3;
    [SerializeField] private SO_Food[] foodInfosCat4;
    [SerializeField] private SO_Food[] foodInfosCat5;
    [SerializeField] private SO_Food[] foodInfosCat6;
    [Space]
    [SerializeField] private Transform foodModelsCat1;
    [SerializeField] private Transform foodModelsCat2;
    [SerializeField] private Transform foodModelsCat3;
    [SerializeField] private Transform foodModelsCat4;
    [SerializeField] private Transform foodModelsCat5;
    [SerializeField] private Transform foodModelsCat6;
    
    private Transform foodModels;
    private int actualCategory = 0;
    private int index = 0;
    private SO_Food[] foodInfos;

    private void Start()
    {
        foodInfos = foodInfosCat1;
        foodModels = foodModelsCat1;
        Display();
    }

    public void ChangeCategory()
    {
        actualCategory = categoryDropdown.value;

        if (actualCategory == 0)
        {
            foodInfos = foodInfosCat1;
            foodModels = foodModelsCat1;
        }
        else if (actualCategory == 1)
        {
            foodInfos = foodInfosCat2;
            foodModels = foodModelsCat2;
        }
        else if (actualCategory == 2)
        {
            foodInfos = foodInfosCat3;
            foodModels = foodModelsCat3;
        }
        else if (actualCategory == 3)
        {
            foodInfos = foodInfosCat4;
            foodModels = foodModelsCat4;
        }
        else if (actualCategory == 4)
        {
            foodInfos = foodInfosCat5;
            foodModels = foodModelsCat5;
        }
        else if (actualCategory == 5)
        {
            foodInfos = foodInfosCat6;
            foodModels = foodModelsCat6;
        }

        //Apagar imgs
        TurnOfImages(foodModelsCat1);
        TurnOfImages(foodModelsCat2);
        TurnOfImages(foodModelsCat3);
        TurnOfImages(foodModelsCat4);
        TurnOfImages(foodModelsCat5);
        TurnOfImages(foodModelsCat6);

        //Reset
        index = -1;
        Next();
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

    private void TurnOfImages(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            parent.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void Order()
    {      
        string url = foodInfos[index].url;
        GlobalURL.globalURL.GetCall(url);
    }
}
