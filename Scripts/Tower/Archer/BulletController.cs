using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,speed*Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "ImpactArea":
                other.transform.root.gameObject.GetComponent<Enemy>().TakeDamage(5); ;
                break;
            case "Floor":
                Destroy(this.gameObject);
                break;
        }
    }
}
