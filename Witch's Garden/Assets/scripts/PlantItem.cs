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

    GardenManager gm;
    void Start()
    {
        gm = FindObjectOfType<GardenManager>();

        InitializeUI();
    }

    public void BuyPlant()
    {
        Debug.Log("Bought " + plant.plantName);
        gm.SelectPlant(this);
    }

    void InitializeUI()
    {
        nameTxt.text = plant.plantName;
        priceTxt.text = "$ " + plant.price;
        icon.sprite = plant.icon;
    }
}
