using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MagazineManager : MonoBehaviour
{
    private MagItem mi;

    public void AddToMagazine(int number)
    {
        mi = GameObject.Find("type" + number).GetComponent<MagItem>();
        mi.AddPlant();
    }

    public void DeleteFromMagazine(int number)
    {
        mi = GameObject.Find("type" + number).GetComponent<MagItem>();
        mi.RemovePlant();
    }
    public int CheckHowMuch(int number)
    {
        mi = GameObject.Find("type" + number).GetComponent<MagItem>();
        return mi.howMuch;
    }
}
