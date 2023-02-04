using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class ClientGenerator : MonoBehaviour
{
    public ClientObject[] clients;
    public SpriteRenderer spRend;
    public bool present = false;
    public int clientNumber;


    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
        spRend.enabled = false;
    }
    private void Update()
    {
        if(!present)
        {
            NewClient();
            present = true;

        }

    }
    
    void NewClient()
    {
        clientNumber = Random.Range(0, clients.Length);
        GetComponent<SpriteRenderer>().sprite = clients[clientNumber].clientNormal;            
        spRend.enabled = true;
    }
    public void IsAngry()
    {
        GetComponent<SpriteRenderer>().sprite = clients[clientNumber].clientAngry;
    }
    public void IsHappy()
    {
        GetComponent<SpriteRenderer>().sprite = clients[clientNumber].clientHappy;
    }
    public void ClientGone()
    {
        present = false;
        spRend.enabled = false;
    }
}
