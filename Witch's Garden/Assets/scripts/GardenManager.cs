using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GardenManager : MonoBehaviour
{
    public PlantItem selectPlant;
    public bool isPlanting = false;
    public int money = 10;
    public TextMeshProUGUI moneyTxt;

    public Color buyColor = Color.green;
    public Color cancelColor = Color.red;

    void Start()
    {
        moneyTxt.text = "$" + money;
    }

    public void SelectPlant(PlantItem newPlant)
    {
        if(selectPlant == newPlant)
        {
            Debug.Log("Deselected " + selectPlant.plant.plantName);
            selectPlant.btnImage.color = buyColor;
            selectPlant.btnTxt.text = "Buy";
            selectPlant = null;
            isPlanting = false;
        }
        else
        {
            if(selectPlant!= null)
            {
                selectPlant.btnImage.color = buyColor;
                selectPlant.btnTxt.text = "Buy";
            }
            selectPlant= newPlant;
            selectPlant.btnImage.color = cancelColor;
            selectPlant.btnTxt.text = "Cancel";
            Debug.Log("Selected " + selectPlant.plant.plantName);
            isPlanting = true;
        }
    }

    public void Transaction(int value)
    {
        money += value;
        moneyTxt.text = "$" + money;
    }
}
