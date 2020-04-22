using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrackSpawn : MonoBehaviour
{
    public GameObject Knight;
    public GameObject spawnPoint;
    private GameObject obj;

    private float countdown = 2f;
    public float timeBetweenSpawn;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        
        obj = Instantiate(Knight, spawnPoint.transform.position, spawnPoint.transform.rotation);
        obj.GetComponent<Knight>().target = spawnPoint.gameObject.GetComponent<Camino>().nextPoint;
        health = obj.GetComponent<Knight>().health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health != 0)
        {
            health = obj.GetComponent<Knight>().health - 5;
        }
        if (countdown <= 0f)
        {
            if (health <= 0)
            {
                obj = null;
                obj = Instantiate(Knight, spawnPoint.transform.position, spawnPoint.transform.rotation);
                obj.GetComponent<Knight>().target = spawnPoint.gameObject.GetComponent<Camino>().nextPoint;
                health = obj.GetComponent<Knight>().health;
            }
            countdown = timeBetweenSpawn;
        }

        countdown -= Time.deltaTime;
    }
}
