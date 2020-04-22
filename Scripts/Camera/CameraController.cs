using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dragSpeed;
    private Vector3 dragOrigin;
    public RadialMenuSpawner menu;

    public float outerLeft;
    public float outerRight;
    public float outerUp;
    public float outerDown;

    public float x;
    public float y;

    void Update()
    {
    Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            if(menu.newMenu.transform.position != dragOrigin)
            {
                if (menu.menu == 1)
                {
                    menu.DestroyMenu();
                }
            }
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

        x = this.transform.position.x;
        y = this.transform.position.z;


        if (move.x > 0f)
        {
            if (this.transform.position.x < outerRight)
            {
                Vector3 moveX = new Vector3(pos.x * dragSpeed, 0, 0);
                transform.Translate(moveX, Space.World);
            }
        }
        else
        {
            if (this.transform.position.x > outerLeft)
            {
                Vector3 moveX = new Vector3(pos.x * dragSpeed, 0, 0);
                transform.Translate(moveX, Space.World);
            }
        }

        if (move.z > 0f)
        {
            if (this.transform.position.z < outerUp)
            {
                Vector3 moveY = new Vector3(0, 0, pos.y * dragSpeed);
                transform.Translate(moveY, Space.World);
            }
        }
        else
        {
            if (this.transform.position.z > outerDown)
            {
                Vector3 moveY = new Vector3(0, 0, pos.y * dragSpeed);
                transform.Translate(moveY, Space.World);
            }
        }
    }
}
