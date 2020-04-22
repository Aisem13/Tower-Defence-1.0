using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public Button button;
    public Image Stars;
    public Image Disable;
    public Text text;
    void Update()
    {
        if(button.interactable == false)
        {
            Stars.enabled = false;
            text.enabled = false;
        }
        else
        {
            Stars.enabled = true;
            text.enabled = true;
        }
    }
}
