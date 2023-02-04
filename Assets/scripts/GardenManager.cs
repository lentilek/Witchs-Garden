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

    public int numberOfOrders = 0;
    public TextMeshProUGUI ordersTxt;
    
    public TextMeshProUGUI timeTxt;
    private float time = 360;
    


    public Color buyColor = Color.green;
    public Color cancelColor = Color.red;

    public bool isSelecting = false;
    public int selectedTool = 0;

    public Image[] buttonsIMG;
    public TextMeshProUGUI[] btnTxt;

    public GameOverScrene gos;
    void Start()
    {
        moneyTxt.text = "$" + money;
        ordersTxt.text = "Zamówienia: " + numberOfOrders;
        timeTxt.text = "Czas: " + time;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = "Czas: " + time;
        if(time < 0)
        {
            gos.Over(numberOfOrders);
        }
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
                buttonsIMG[selectedTool-1].color = buyColor;
                if (selectedTool == 4) btnTxt[selectedTool - 1].text = "SZYBSZY WZROST $2";
                else if (selectedTool == 5) btnTxt[selectedTool - 1].text = "WIÊCEJ PLONÓW $5";
                else
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
