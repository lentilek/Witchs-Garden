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

    //private float py;
    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        gm = transform.parent.GetComponent<GardenManager>();
        mm = GameObject.Find("magazine").GetComponent<MagazineManager>();
    }

    void Update()
    {
        if (!isPlanted)
            return;

        timer -= Time.deltaTime;
        if (timer < 0 && plantStage < selectedPlant.plantStages.Length - 1)
        {
            timer = selectedPlant.timeBS;
            plantStage++;
            UpdatePlant();
        }

    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
            if (plantStage == selectedPlant.plantStages.Length - 1 && !gm.isPlanting)
            {
                Harvest();
            }
        }
        else if (gm.isPlanting && gm.selectPlant.plant.price <= gm.money) 
        {
            Plant(gm.selectPlant.plant);
        }
    }

    void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
        gm.Transaction((selectedPlant.price) * 2);

        mm.AddToMagazine(selectedPlant.plantNumber);
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
