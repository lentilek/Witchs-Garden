using UnityEngine;

public class PlotManager : MonoBehaviour
{
    private bool isPlanted = false;
    private SpriteRenderer plant;
    private BoxCollider2D plantCollider;

    private int plantStage = 0;
    private float timer;

    private PlantObject selectedPlant;

    private GardenManager gm;
    private MagazineManager mm;
    //private WeedManager wm;

    SpriteRenderer plot;

    bool isDry = true;
    public Sprite drySprite;
    public Sprite normalSprite;

    private float speed = 1;
    private bool isDouble = false;

    /*private bool isWeed = false;
    private float timerWeed;
    public int plotNumber;*/

    public SpriteRenderer weedPlace;
    private bool isWeed = false;
    public Sprite[] weeds;
    private float weedTimer = 5;
    //private float py;
    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        gm = transform.parent.GetComponent<GardenManager>();
        //wm = GameObject.Find("weedsPlace").GetComponent<WeedManager>();
        mm = GameObject.Find("magazine").GetComponent<MagazineManager>();
        plot = GetComponent<SpriteRenderer>();
        plot.sprite = drySprite;
        weedPlace.gameObject.SetActive(false);

    }

    void Update()
    {
        if (isPlanted && !isDry)
        {
            timer -= speed * Time.deltaTime;
            if (timer < 0 && plantStage < selectedPlant.plantStages.Length - 1)
            {
                timer = selectedPlant.timeBS;
                plantStage++;
                UpdatePlant();
            }
        }
        /*if (isPlanted && isWeed) timerWeed -= Time.deltaTime;
        if (isPlanted && timerWeed< 0)
        {
            isPlanted = false;
            plant.gameObject.SetActive(false);
            //gm.Transaction((selectedPlant.price) * 2);
            isDry = true;
            plot.sprite = drySprite;
            speed = 1f;
            isDouble= false;
        }*/
        if(!isWeed)
            weedTimer -= Time.deltaTime;

        if (weedTimer < 0 && !isWeed)
        {
            int rand = Random.Range(0, 30);
            if(rand < 3)
            {
                //weed
                weedPlace.sprite = weeds[rand];
                weedPlace.gameObject.SetActive(true);
                isWeed= true;
                weedTimer = 6;

            }
            else
            {
                weedTimer = 5;
            }
        }
        if(isPlanted && isWeed) 
            weedTimer-= Time.deltaTime;
        if(weedTimer < 0 && isWeed & isPlanted) 
        {
            isPlanted = false;
            plant.gameObject.SetActive(false);
            //gm.Transaction((selectedPlant.price) * 2);
            isDry = true;
            plot.sprite = drySprite;
            speed = 1f;
            isDouble = false;
            weedTimer = 6;
        }

    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
            if (plantStage == selectedPlant.plantStages.Length - 1 && !gm.isPlanting && !gm.isSelecting)
            {
                Harvest();
            }
        }
        else if (gm.isPlanting && gm.selectPlant.plant.price <= gm.money) 
        {
            Plant(gm.selectPlant.plant);
        }
        if (gm.isSelecting)
        {
            switch(gm.selectedTool)
            {
                case 1:
                    isDry = false;
                    plot.sprite = normalSprite;
                    if(isPlanted) UpdatePlant();
                    break;
                case 3:
                    /*if (isWeed)
                    {
                        isWeed = false;
                        //destroy weed
                        wm.DestroyWeed(plotNumber);
                    }*/
                    weedPlace.gameObject.SetActive(false);
                    isWeed = false;
                    weedTimer = 5;
                    break;
                case 4:
                    if (gm.money >= 3 && speed < 2)
                    {
                        gm.Transaction(-3);
                        if (speed < 2) speed += 0.5f;
                    } 
                    break;
                case 5:
                    if (gm.money >= 5 && !isDouble)
                    {
                        gm.Transaction(-5);
                        isDouble= true;
                    }
                    break;
                default: 
                    break;
            }
        }
    }

    /*public void TheresWeed()
    {
        isWeed = true;
        timerWeed = 6;
    }
    public bool IsThereWeed()
    {
        if(isWeed) return true;
        else return false;
    }*/

    void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
        //gm.Transaction((selectedPlant.price) * 2);
        isDry= true;
        plot.sprite = drySprite;
        speed = 1f;
        mm.AddToMagazine(selectedPlant.plantNumber);
        if(isDouble) mm.AddToMagazine(selectedPlant.plantNumber);
        isDouble=false;
    }

    void Plant(PlantObject newPlant)
    {
        selectedPlant= newPlant;
        isPlanted = true;

        gm.Transaction(-selectedPlant.price);

        plantStage = 0;
        UpdatePlant();
        timer = selectedPlant.timeBS;
        plant.gameObject.SetActive(true);
    }

    void UpdatePlant()
    {
        plant.sprite = selectedPlant.plantStages[plantStage];
        plantCollider.size = plant.sprite.bounds.size;
        //py = plant.bounds.size.y;
        //py = py * 0.5;
        plantCollider.offset = new Vector2(0, plant.bounds.size.y/2);
    }
}
