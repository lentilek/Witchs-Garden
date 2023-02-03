using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GardenManager : MonoBehaviour
{
    public PlantItem selectPlant;
    public bool isPlanting = false;
    public int money;
    public TextMeshProUGUI moneyTxt;
    private int numberOfOrders = 0;
    public TextMeshProUGUI ordersTxt;
    public int neededOrders;

    public Color buyColor = Color.green;
    public Color cancelColor = Color.red;

    public bool isSelecting = false;
    public int selectedTool = 0;

    public Image[] buttonsIMG;
    public TextMeshProUGUI[] btnTxt;

    void Start()
    {
        moneyTxt.text = "$" + money;
        ordersTxt.text = "Zamówienia: " + numberOfOrders;
    }

    public void SelectPlant(PlantItem newPlant)
    {
        if(selectPlant == newPlant)
        {
            //Debug.Log("Deselected " + selectPlant.plant.plantName);
            CheckSelection();
        }
        else
        {
            CheckSelection();
            selectPlant= newPlant;
            selectPlant.btnImage.color = cancelColor;
            selectPlant.btnTxt.text = "ODZNACZ";
            //Debug.Log("Selected " + selectPlant.plant.plantName);
            isPlanting = true;
        }
    }

    public void SelectTool(int toolNumber)
    {
        if(toolNumber == selectedTool)
        {
            //deselect
            CheckSelection();
        }
        else
        {
            //select
            CheckSelection();
            isSelecting= true;
            selectedTool= toolNumber;
            //buttonsIMG[toolNumber - 1].sprite = selectedButton;
            buttonsIMG[selectedTool - 1].color = cancelColor;
            btnTxt[selectedTool - 1].text = "ODZNACZ";
        }
    }

    void CheckSelection()
    {
        if(isPlanting)
        {
            isPlanting= false;
            if(selectPlant !=null) { 
                selectPlant.btnImage.color = buyColor;
                selectPlant.btnTxt.text = "KUP";
                selectPlant = null;
            }
        }
        if(isSelecting)
        {
            if(selectedTool > 0)
            {
                //buttonsIMG[selectedTool - 1].sprite = normalButton;
                buttonsIMG[selectedTool-1].color = buyColor;
                btnTxt[selectedTool - 1].text = "WYBIERZ";
            }
            isSelecting= false;
            selectedTool = 0;
        }
    }

    public void Transaction(int value)
    {
        money += value;
        moneyTxt.text = "$" + money;
    }
    public void OrdersIncrease()
    {
        numberOfOrders++;
        ordersTxt.text = "Zamówienia: " + numberOfOrders;
    }
}
