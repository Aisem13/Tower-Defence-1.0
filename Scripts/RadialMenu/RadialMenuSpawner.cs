using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenuSpawner : MonoBehaviour
{
    public static RadialMenuSpawner ins;
    public RadialMenu menuPrefab;
    public RadialMenu newMenu;
    public int menu = 0;

    private void Awake()
    {
        ins = this;
    }

    public void SpawnMenu(Interactable obj)
    {
        if(menu == 0)
        {
            newMenu = Instantiate(menuPrefab) as RadialMenu;
            newMenu.transform.SetParent(transform, false);
            newMenu.transform.position = obj.sphere.transform.position;
            Debug.Log(obj.sphere.transform.position);
            newMenu.label.text = obj.title.ToUpper();
            newMenu.SpawnButtons(obj);
            menu = 1;
        }
        else
        {
            DestroyMenu();
        }
    }

    public void DestroyMenu()
    {
        newMenu.Destroy();
        menu = 0;
    }
}
