using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyScript : MonoBehaviour
{
    private Collider clr;
    private bool canDealDamageLastFrame;

    void Start()
    {
        clr = GetComponent<Collider>();
        //collider.enabled = false;
        canDealDamageLastFrame = false;
    }

    void Update()
    {
        bool canDealDamage = GameObject.Find("SledgeHammer").GetComponent<Animator>().GetBool("canDealDamage");

        if (canDealDamage)
        {
            clr.enabled = true;
            canDealDamageLastFrame = true;
        }
        else if (canDealDamageLastFrame)
        {
            StartCoroutine(DisableColliderAfterDelay(0.01f));
            canDealDamageLastFrame = false;
        }
    }

    IEnumerator DisableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        clr.enabled = false;
    }

    void OnTriggerEnter(Collider obj)
    {
        
        if (obj.gameObject.CompareTag("Enemy") && !GameObject.Find("DayNightController").GetComponent<dayNightControllerScript>().isNight)
        {
            Debug.Log("hit enemy");
            obj.gameObject.GetComponent<EnemyAI>().isDead = true;
        }
        
        
    }
}
