using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crow", menuName = "Crow")]
public class CrowObject : ScriptableObject
{
    public int number;
    public Sprite flying;
    public Sprite sitting;
    public Sprite bonked;
    public int hitbox;
}
