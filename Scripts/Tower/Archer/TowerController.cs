using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    // Visual
    public GameObject towerHead;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
