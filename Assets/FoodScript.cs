using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    [SerializeField] private float foodHealAmount;
    private HungerControllerScript HungerControl;
    void Start(){
        HungerControl = FindObjectOfType<HungerControllerScript>();
    }
    void OnTriggerEnter(Collider obj){
        if (obj.gameObject.CompareTag("Player"))
        {
            HungerControl.IncreaseHunger(foodHealAmount);
            Destroy(this.gameObject.transform.parent.gameObject,0.1f);
        }
    }
}
