using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBulletController : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "ImpactArea":
                other.transform.root.gameObject.GetComponent<Enemy>().health -= 5;
                break;
            case "Floor":
                Destroy(this.gameObject);
                break;
        }
    }
}
