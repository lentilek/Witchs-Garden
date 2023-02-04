using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowFly : MonoBehaviour
{
    public bool isFlying = false;
    public CrowObject[] crows;
    public SpriteRenderer thisCrow;
    private int rand;
    private float timer;
    private GardenManager gm;
    public int hp;
    public CrowSit cs;
    public bool bonked = false;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GardenManager>();
        thisCrow = gameObject.GetComponent<SpriteRenderer>();
        //thisCrow.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlying && !bonked)
        {
            timer -= Time.deltaTime;
            if (timer < 0 && !cs.isSitting)
            {
                //crow land
                Debug.Log("Land");
                isFlying = false;
                this.gameObject.SetActive(false);
                cs.ItSits(hp, rand);
            }
            else if (cs.isSitting) timer = 5;
        }
        else if (bonked)
        {
            timer-= Time.deltaTime;
            if(timer < 0)
            {
                isFlying= false;
                //thisCrow.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
                bonked = false;
            }
        }
    }

    private void OnMouseDown()
    {
        if(isFlying && gm.selectedTool == 2)
        {
            
            hp -= 1;
            if(hp == 0)
            {
                bonked = true;
                timer = 3;
                thisCrow.sprite = crows[rand].bonked;
            }
        }
    }

    public void NewCrow()
    {
        //get crow
        Debug.Log("croiw");
        isFlying= true;
        timer = 6;
        rand = Random.Range(0, crows.Length);
        this.gameObject.SetActive(true);
        hp = crows[rand].hitbox;
        thisCrow.sprite = crows[rand].flying;
        //thisCrow.gameObject.SetActive(true);
    }
}
