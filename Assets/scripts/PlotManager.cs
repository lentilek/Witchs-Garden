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

    SpriteRenderer plot;

    bool isDry = true;
    public Sprite drySprite;
    public Sprite normalSprite;

    private float speed = 1;
    private bool isDouble = false;

    public SpriteRenderer weedPlace;
    private bool isWeed = false;
    public Sprite[] weeds;
    private float weedTimer = 10;

    public SpriteRenderer fert1;
    public SpriteRenderer fert2;
    public SpriteRenderer fert3;
    public SpriteRenderer done;
    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        gm = transform.parent.GetComponent<GardenManager>();
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

        if(!isWeed)
            weedTimer -= Time.deltaTime;

        if (weedTimer < 0 && !isWeed)
        {
            int rand = Random.Range(0, 30);
            if(rand < 3)
            {
                weedPlace.sprite = weeds[rand];
                weedPlace.gameObject.SetActive(true);
                isWeed= true;
                weedTimer = 6;

            }
            else
            {
                weedTimer = 10;
            }
        }
        if(isPlanted && isWeed) 
            weedTimer-= Time.deltaTime;
        if(weedTimer < 0 && isWeed & isPlanted) 
        {
            isPlanted = false;
            plant.gameObject.SetActive(false);
            isDry = true;
            plot.sprite = drySprite;
            speed = 1f;
            isDouble = false;
            weedTimer = 6;
            fert1.gameObject.SetActive(false);
            fert2.gameObject.SetActive(false);
            fert3.gameObject.SetActive(false);
            done.gameObject.SetActive(false);
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
                    weedPlace.gameObject.SetActive(false);
                    isWeed = false;
                    weedTimer = 10;
                    break;
                case 4:
                    if (gm.money >= 2 && speed < 2)
                    {
                        gm.Transaction(-2);
                        if(speed == 1) fert1.gameObject.SetActive(true);
                        else if(speed == 1.5f) fert2.gameObject.SetActive(true);
                        speed += 0.5f;
                    } 
                    break;
                case 5:
                    if (gm.money >= 5 && !isDouble)
                    {
                        gm.Transaction(-5);
                        fert3.gameObject.SetActive(true);
                        isDouble= true;
                    }
                    break;
                default: 
                    break;
            }
        }
    }


    void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
        isDry= true;
        plot.sprite = drySprite;
        speed = 1f;
        mm.AddToMagazine(selectedPlant.plantNumber);
        if(isDouble) mm.AddToMagazine(selectedPlant.plantNumber);
        isDouble=false;
        fert1.gameObject.SetActive(false);
        fert2.gameObject.SetActive(false);
        fert3.gameObject.SetActive(false);
        done.gameObject.SetActive(false);
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
        plantCollider.offset = new Vector2(0, plant.bounds.size.y/2);
        if (plantStage == 2) done.gameObject.SetActive(true);
    }
}
