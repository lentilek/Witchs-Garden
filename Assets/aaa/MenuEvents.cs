using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuEvents : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;

    private void Start()
    {
        mixer.GetFloat("Volume", out value);
        volumeSlider.value = value;
    }
    public void SetVolume()
    {
       mixer.SetFloat("Volume", volumeSlider.value);
     
    }
    public void LoadLevel()
    {
       UnityEngine.SceneManagement.SceneManager.LoadScene("game");
    }
    public void Tutorial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("tutorial");
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
