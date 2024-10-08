using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class OrderItem : MonoBehaviour
{
    public SpriteRenderer spRend;
    public int number;
    //public bool isOn = false;

    public string what;

    private Order ord;
    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
        spRend.enabled = false;
        ord = GameObject.Find(what).GetComponent<Order>();
    }

    void Update()
    {
        if (ord.isOrder && ord.order.Count >= number+1)// && !isOn)
        {
            GetComponent<SpriteRenderer>().sprite = ord.order[number].icon;
            spRend.enabled = true;
            //isOn = true;
        }
        else
        {
            spRend.enabled = false;
        }

    }
}
