using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MagItem : MonoBehaviour
{
    public PlantObject plant;

    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI howMuchTxt;
    public int howMuch = 0;
    public Image icon;

    private void Start()
    {
        nameTxt.text = plant.plantName;
        howMuchTxt.text = "" + howMuch;
        icon.sprite = plant.icon;
    }

    public void AddPlant()
    {
        howMuch++;
        howMuchTxt.text = "" + howMuch;
    }

    public void RemovePlant()
    {
        howMuch--;
        howMuchTxt.text = "" + howMuch;
    }
}
