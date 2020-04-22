using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageDetector : MonoBehaviour
{
    MageController tcRoot;
    Enemy targetEnemy;
    public Transform target;
    public bool useLaser = false;
    void Start()
    {
        tcRoot = transform.parent.gameObject.GetComponent<MageController>();
        tcRoot.line.enabled = false;
        tcRoot.impactEffect.Stop();
        tcRoot.impactLight.enabled = false;
    }
    void Update()
    {
        if (target != null)
        {
            tcRoot.towerHead.transform.LookAt(new Vector3(target.position.x, tcRoot.towerHead.transform.position.y, target.position.z));
            if(useLaser == true)
            {
                Laser();
            }
        }
        else
        {
            if (useLaser)
            {
                if (tcRoot.line.enabled)
                {
                    tcRoot.line.enabled = false;
                    tcRoot.impactEffect.Stop();
                    tcRoot.impactLight.enabled = false;
                }
            }
        }

    }

    void Laser()
    {
        targetEnemy.TakeDamage(tcRoot.damageOverTime * Time.deltaTime);

        if (!tcRoot.line.enabled)
        {
            tcRoot.line.enabled = true;
            tcRoot.impactEffect.Play();
            tcRoot.impactLight.enabled = true;
        }

        tcRoot.line.SetPosition(0,tcRoot.bulletSpawn.position);
        tcRoot.line.SetPosition(1, target.position);

        Vector3 dir = tcRoot.bulletSpawn.position - target.position;

        tcRoot.impactEffect.transform.position = target.position + dir.normalized;
        tcRoot.impactEffect.transform.rotation = Quaternion.LookRotation(dir);
        
    }
    void OnTriggerStay(Collider obj)
    {
        switch (obj.tag)
        {
            case "Enemy":
                if (target == null)
                {
                    target = obj.GetComponent<Enemy>().damagePoint;
                    targetEnemy = obj.GetComponent<Enemy>();
                    useLaser = true;
                }
                break;
        }
    }

    void OnTriggerExit(Collider obj)
    {
        target = null;
    }
}
