using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Client", menuName = "Client")]
public class ClientObject : ScriptableObject
{
    public string clientName;
    public Sprite clientNormal;
    public Sprite clientHappy;
    public Sprite clientAngry;
}
