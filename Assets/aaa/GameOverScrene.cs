using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScrene : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public void Over(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "ZAMÓWIENIA: " + score.ToString();
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

