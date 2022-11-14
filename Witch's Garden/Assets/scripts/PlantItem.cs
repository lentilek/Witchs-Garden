using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
    public PlantObject plant;

    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI priceTxt;
    public Image icon;

    void Start()
    {
        nameTxt.text = plant.plantName;
        priceTxt.text = "$ " + plant.price;
        icon.sprite = plant.icon;
    }

    public void BuyPlant()
    {
        Debug.Log("Bought " + plant.plantName);
    }
}
