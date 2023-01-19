using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientGenerator : MonoBehaviour
{
    public ClientObject[] clients;
    public SpriteRenderer spRend;
    public bool present = false;

    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
        spRend.enabled = false;
    }
    private void Update()
    {
        if(!present)
        {
            int rand2 = Random.Range(0, 10);
            if(rand2 > 6)
            {
                NewClient();
                present = true;
            }
            
        }

    }
    
    void NewClient()
    {
        int rand = Random.Range(0, clients.Length);
        GetComponent<SpriteRenderer>().sprite = clients[rand].clientNormal;            
        spRend.enabled = true;
    }
}
