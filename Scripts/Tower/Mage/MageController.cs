using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageController : MonoBehaviour
{
    // Visual
    public GameObject towerHead;
    public Transform bulletSpawn;
    public GameObject rangeAttackVisual;

    //Laser
    public ParticleSystem impactEffect;
    public Light impactLight;
    public int damageOverTime = 2;

    //public GameObject bulletReference;
    public LineRenderer line;
    public float fireRate;

    //Propiedades
    public float rangeAttack;

    // Start is called before the first frame update
    void Start()
    {
        rangeAttackVisual.GetComponent<SphereCollider>().radius = rangeAttack;
    }
}
