using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowGenerator : MonoBehaviour
{
    private float timer = 15;
    //public SpriteRenderer[] places;
    public CrowFly cf1;
    public CrowFly cf2;
    public CrowFly cf3;
    private int rand;
    void Start()
    {
        //cf1 = GameObject.Find("fly1").GetComponent<CrowFly>();
        //cf[1] = GameObject.Find("fly2").GetComponent<CrowFly>();
        //cf[2] = GameObject.Find("fly3").GetComponent<CrowFly>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            //int rand = Random.Range(0, places.Length-1);
            rand = Random.Range(0, 3);
            //rand = 0;
            switch (rand)
            {
                case 0:
                    //Debug.Log(rand);
                    if (!cf1.isFlying)
                    {
                        cf1.NewCrow();
                    }
                    break;
                case 1:
                    if (!cf2.isFlying)
                    {
                        cf2.NewCrow();
                    }
                    break;
                case 2:
                    if (!cf3.isFlying)
                    {
                        cf3.NewCrow();
                    }
                    break;
                default:
                    break;
            }
            timer = 15;
            
        }
    }
}
