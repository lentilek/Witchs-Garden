using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Client : MonoBehaviour
{
    public ClientObject client;

    public Sprite clientImage;
    public Image dymek;
    public Sprite[] order; 

    //GardenManager gm;
    void Start()
    {

    }

    public void Order()
    {
        Debug.Log("order");
    }


}
