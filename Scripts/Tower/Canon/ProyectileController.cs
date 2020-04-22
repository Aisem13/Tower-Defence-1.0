using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "ImpactArea":
                other.transform.root.gameObject.GetComponent<Enemy>().TakeDamage(5);
                break;
            case "Floor":
                Destroy(this.gameObject);
                break;
        }
    }
}
