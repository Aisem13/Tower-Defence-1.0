using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float startHealth;
    public float health;
    public float enemyHealt;
    public int position;
    public Transform target;
    public Transform damagePoint;
    public GameObject BarPrefab;
    public Image Bar;
    public Image BarFilled;
    public GameObject impactArea;
    public Animator animationController;
    public bool translate = true;
   
    void Start()
    {
        health = startHealth;
        animationController = GetComponent<Animator>();
        Bar = Instantiate(BarPrefab,GameObject.FindWithTag("HealthBar").transform).GetComponent<Image>();
        BarFilled = new List<Image>(Bar.GetComponentsInChildren<Image>()).Find(img => img != Bar);
    }

    void Update()
    {
        Bar.transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x,3.5f,transform.position.z));
        if (translate == true)
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
        BarFilled.fillAmount = health / startHealth;   
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
            Destroy(Bar);
            PlayerStats.Money += 10;
            PlayerStats.killEnemy += 1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "WayPoint":
                target = other.gameObject.GetComponent<Camino>().nextPoint;
                break;
            case "Knight":
                enemyHealt = other.transform.root.gameObject.GetComponent<Knight>().health;
                break;
            case "ImpactKinght":
                other.transform.root.gameObject.GetComponent<Knight>().health -= 5;
                enemyHealt = other.transform.root.gameObject.GetComponent<Knight>().health;
                break;
        }
    }
    void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "Knight":   
                translate = false;
                animationController.SetTrigger("Attack");
                enemyHealt = other.transform.root.gameObject.GetComponent<Knight>().health;
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(enemyHealt <= 0)
        {
            translate = true;
            animationController.SetTrigger("Run");
        }
    }
}
