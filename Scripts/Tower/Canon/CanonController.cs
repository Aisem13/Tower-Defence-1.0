using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    // Visual
    public Transform bulletSpawn;
    public GameObject rangeAttackVisual;
    public GameObject bulletReference;
    public float fireRate;

    //Propiedades
    public float rangeAttack;

    // Start is called before the first frame update
    void Start()
    {
        rangeAttackVisual.GetComponent<SphereCollider>().radius = rangeAttack;
    }
}
