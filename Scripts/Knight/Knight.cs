using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public Animator animationController;
    public Transform target;
    public float speed;
    public float health;
    public float enemyHealt;
    public bool translate = true;

    // Start is called before the first frame update
    void Start()
    {
        animationController = GetComponent<Animator>();
          
    }

    // Update is called once per frame
    void Update()
    {
        if(translate == true)
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }  
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "ImpactArea":
                other.transform.root.gameObject.GetComponent<Enemy>().TakeDamage(5); ;
                enemyHealt = other.transform.root.gameObject.GetComponent<Enemy>().health;
                break;
            case "Enemy":
                enemyHealt = other.transform.root.gameObject.GetComponent<Enemy>().health;
                if(enemyHealt > 0)
                {
                    animationController.SetTrigger("Attack");
                }
                break;          
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "run":
                translate = false;
                animationController.SetTrigger("Idle");
                transform.rotation = target.rotation;
                break;
        }
    }
}
