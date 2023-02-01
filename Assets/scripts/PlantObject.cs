using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class PlantObject : ScriptableObject
{
    public string plantName;
    public int plantNumber;
    public Sprite[] plantStages;
    public float timeBS;
    public int price;
    public Sprite icon;
}
