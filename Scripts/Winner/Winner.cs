using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Winner : MonoBehaviour
{
    public Slider slider;
    public Image star01;
    public Image star02;
    public Image star03;

    void OnEnable()
    {
        if(PlayerStats.starValue <= 50)
        {
            star01.enabled = true;
        }
        else if(PlayerStats.starValue > 50 && PlayerStats.starValue <= 80)
        {
            star01.enabled = true;
            star02.enabled = true;
        }
        else if (PlayerStats.starValue > 80)
        {
            star01.enabled = true;
            star02.enabled = true;
            star03.enabled = true;
        }

        slider.value = PlayerStats.sliderValue;
        Debug.Log(PlayerStats.starValue);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        Debug.Log("Go to nextLevel.");
    }
}
