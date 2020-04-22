using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public AudioSource music;
    public Slider musicSlider;
    public Slider soundSlider;

    private float defaultVolumeMusic;
    //private float defaultVolumeSound;

    public GameObject ui;
    public GameObject option;

    void Start()
    {
        defaultVolumeMusic = music.volume;
        musicSlider.value = music.volume * 100;
    }
    
    void Update()
    {
        music.volume = musicSlider.value / 100; 
    }

    public void Okay()
    {
        ui.SetActive(!ui.activeSelf);
        option.SetActive(!option.activeSelf);
        defaultVolumeMusic = music.volume;
    }

    public void Quit()
    {
        music.volume = defaultVolumeMusic;
        musicSlider.value = defaultVolumeMusic * 100;
        ui.SetActive(!ui.activeSelf);
        option.SetActive(!option.activeSelf);
    }


}
