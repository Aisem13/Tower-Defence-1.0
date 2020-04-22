using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Slider slider;

    void OnEnable()
    {
        slider.value = PlayerStats.sliderValue;
        Debug.Log(slider.value);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Go to menu.");
    }

    public void NextLevel()
    {
        Debug.Log("Go to nextLevel.");
    }
}
