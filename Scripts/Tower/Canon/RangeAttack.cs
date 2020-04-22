using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    CanonController tcRoot;
    
    float timeNextBullet;
    public Transform target;
    private GameObject shootedParticle;

    void Start()
    {
        tcRoot = transform.parent.gameObject.GetComponent<CanonController>();
    }
    void Update()
    {
        if (target != null)
        {
            if (Time.time > timeNextBullet)
            {
                Attack();
                timeNextBullet = Time.time + tcRoot.fireRate;
            }
        }

    }
    void OnTriggerStay(Collider obj)
    {
        switch (obj.tag)
        {
            case "Enemy":
                if (target == null)
                {
                    target = obj.GetComponent<Enemy>().damagePoint;
                }
                break;
        }
    }

    void OnTriggerExit(Collider obj)
    {
        target = null;
    }

    public void Attack()
    {
        Vector3 targetPosition = new Vector3(target.position.x , target.position.y, target.position.z - 10);
        Vector3 direction = targetPosition - tcRoot.transform.position;            
        float h = direction.y;                                            
        direction.y = 0;                                                
        float distance = direction.magnitude;
        float a = 800 * Mathf.Deg2Rad;                               
        direction.y = distance * Mathf.Tan(a);                            
        distance += h / Mathf.Tan(a);                                        

        float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * a));

        shootedParticle = Instantiate(tcRoot.bulletReference, tcRoot.bulletSpawn.transform.position, tcRoot.bulletSpawn.transform.rotation);
        shootedParticle.GetComponent<Rigidbody>().velocity = velocity * direction.normalized;
        Physics.IgnoreCollision(shootedParticle.GetComponent<Collider>(), GetComponent<Collider>());
    }
}
