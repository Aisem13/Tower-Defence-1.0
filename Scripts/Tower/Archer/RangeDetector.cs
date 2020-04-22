using UnityEngine;

public class RangeDetector : MonoBehaviour
{
    TowerController tcRoot;
    public Animator archerAnimationController;
    float timeNextBullet;
    public Transform target;

    void Start()
    {
        tcRoot = transform.parent.gameObject.GetComponent<TowerController>();
        archerAnimationController = tcRoot.towerHead.GetComponent<Animator>();
    }
    void Update()
    {
        if(target != null)
        {
            tcRoot.towerHead.transform.LookAt(new Vector3(target.position.x, target.position.y, target.position.z));
            archerAnimationController.SetTrigger("Attack");
            if (Time.time > timeNextBullet)
            {
                Instantiate(tcRoot.bulletReference, tcRoot.bulletSpawn.position, tcRoot.bulletSpawn.rotation);
                timeNextBullet = Time.time + tcRoot.fireRate;
            }
        }
        
    }
    void OnTriggerStay(Collider obj)
    {
        switch (obj.tag)
        {
            case "Enemy":
                if(target == null)
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
}
