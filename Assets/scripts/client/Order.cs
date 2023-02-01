using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Order : MonoBehaviour
{
    public SpriteRenderer spRend;
    public bool isOrder = false;
    public PlantObject[] plantsToOrder;
    //public PlantObject[] order;
    public List<PlantObject> order = new List<PlantObject>();

    public string what;
    private ClientGenerator cg;
    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
        spRend.enabled = false;
        //cg = transform.GetComponent<ClientGenerator>();
        //cg = FindObjectOfType<ClientGenerator>();
        cg = GameObject.Find(what).GetComponent<ClientGenerator>();
    }

    void Update()
    {
        if(cg.present && !isOrder)
        {
            CreateOrder();
            isOrder = true;
        }
    }
    void CreateOrder()
    {
        spRend.enabled = true;
        int number = Random.Range(1, 4);
        //Debug.Log("numer"+ number);
        for(int i=1; i<=number; i++)
        {
            int rand = Random.Range(0, plantsToOrder.Length);
            order.Add(plantsToOrder[rand]);
        }
        //Debug.Log(order.Count);
    }
}
