using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [System.Serializable]
    public class Action
    {
        public Color color;
        public Sprite sprite;
        public string title;
    }

    public Action[] options;
    public GameObject sphere;
    public GameObject Point;

    public GameObject Archer;
    public GameObject Canon;
    public GameObject Mage;
    public GameObject Barrack;

    public string title;
    void Start()
    {
        if(title == null || title == "")
        {
            title = gameObject.name;
        }   
    }

    void OnMouseUp()
    {
        RadialMenuSpawner.ins.SpawnMenu(this);
    }

}
