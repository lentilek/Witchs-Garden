using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScrene : MonoBehaviour
{
    //public GardenManager gm;
    public TextMeshProUGUI pointsText;

    void Start()
    {
        //gm = FindObjectOfType<GardenManager>();
        //pointsText.text = "ZAM�WIENIA: "+ gm.numberOfOrders;
    }
    public void Over(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "ZAM�WIENIA: " + score.ToString();// + "Points";
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("game");
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

