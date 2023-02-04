using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowGenerator : MonoBehaviour
{
    private float timer = 15;
    public CrowFly cf1;
    public CrowFly cf2;
    public CrowFly cf3;
    private int rand;

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            rand = Random.Range(0, 3);
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
