using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MagazineManager : MonoBehaviour
{
    private MagItem mi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
