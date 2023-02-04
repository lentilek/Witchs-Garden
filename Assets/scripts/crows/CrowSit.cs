using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.XR;

public class CrowSit : MonoBehaviour
{
    private int hp;
    private int number;
    public CrowObject[] crows;
    private SpriteRenderer thisCrow;
    private GardenManager gm;
    public bool isSitting = false;
    private float timer;
    private bool bonked = false;
    public PlotManager[] plots;
    void Start()
    {
        gm = FindObjectOfType<GardenManager>();
        thisCrow = gameObject.GetComponent<SpriteRenderer>();
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isSitting && !bonked)
        {

            timer -= Time.deltaTime;
            if (timer < 0)
            {
                //eat and go
                for(int i = 0; i < plots.Length; i++)
                {
                    if (plots[i].isPlanted)
                    {
                        //nom
                        plots[i].Nom();
                    }
                }

                //Debug.Log("nom");
                isSitting= false;
                this.gameObject.SetActive(false);
            }
        }
        else if (bonked)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                isSitting = false;
                this.gameObject.SetActive(false);
                bonked = false; 
            }
        }

    }
    private void OnMouseDown()
    {
        if (isSitting && gm.selectedTool == 2)
        {

            hp -= 1;
            if (hp == 0)
            {
                bonked = true;
                timer = 3;
                thisCrow.sprite = crows[number].bonked;
            }
        }
    }

    public void ItSits(int hit, int nr)
    {
        hp = hit;
        number = nr;
        this.gameObject.SetActive(true);
        thisCrow.sprite = crows[number].sitting;
        
        isSitting= true;
        timer = 5;
    }
}
