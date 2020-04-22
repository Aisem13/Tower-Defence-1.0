using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destiny : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            PlayerStats.Lives -= 1;
            PlayerStats.destroyEnemy += 1;
            Destroy(other.gameObject);
        }
    }
}
