using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Order : MonoBehaviour
{
    public SpriteRenderer spRend;
    public bool isOrder = false;
    public int number;
    public PlantObject[] plantsToOrder;
    //public PlantObject[] order;
    public List<PlantObject> order = new List<PlantObject>();
    private float timer;
    private bool waiting = false;
    private int maks;

    public string what;
    private ClientGenerator cg;
    private MagazineManager mm;
    private GardenManager gm;

    //public Color goodColor = Color.green;
    public SpriteRenderer dymek;
    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
        spRend.enabled = false;
        //cg = transform.GetComponent<ClientGenerator>();
        //cg = FindObjectOfType<ClientGenerator>();
        cg = GameObject.Find(what).GetComponent<ClientGenerator>();
        mm = GameObject.Find("magazine").GetComponent<MagazineManager>();
        gm = FindObjectOfType<GardenManager>();
    }

    void Update()
    {
        if(cg.present && !isOrder)
        {
            CreateOrder();
            isOrder = true;
        }

        if (!waiting)
            return;

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            cg.ClientGone();
            waiting = false;
            isOrder = false;
            order.Clear();
            dymek.color= Color.white;
        }
    }

    private void OnMouseDown()
    {
        bool isEnough = true;
        for(int i = 0; i < number; i++)
        {
            if (mm.CheckHowMuch(order[i].plantNumber)>0)
            {
                mm.DeleteFromMagazine(order[i].plantNumber);
            }
            else
            {
                isEnough = false;
            }
        }
        if (isEnough == true)
        {
            for(int i = 0; i<number; i++)
            {
                gm.Transaction(order[i].price * 2);
            }

            cg.IsHappy();
            dymek.color = Color.green;
            gm.OrdersIncrease();
            timer = 3;
            waiting = true;
        }
        else
        {
            cg.IsAngry();
        }
        
    }

    void CreateOrder()
    {
        spRend.enabled = true;
        number = Random.Range(1, 4);
        //Debug.Log("numer"+ number);
        if (gm.numberOfOrders < 6)
        {
            maks = 6;
        }
        else maks = plantsToOrder.Length;
        for(int i=1; i<=number; i++)
        {
            int rand = Random.Range(0, maks);
            order.Add(plantsToOrder[rand]);
        }
        //Debug.Log(order.Count);
    }
}
