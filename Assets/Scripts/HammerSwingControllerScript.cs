using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerSwingControllerScript : MonoBehaviour
{
    private Animator hammerAnimator;

    void Start()
    {
        // Cache the Animator component reference
        hammerAnimator = GameObject.Find("SledgeHammer").GetComponent<Animator>();
        // Initialize the animation parameters
        Set("isSwinging", false);
    }

    void Update()
    {
        //Debug.Log(Get("isSwinging"));
        if (Input.GetMouseButtonDown(0) && !Get("isSwinging") && !GameObject.Find("DayNightController").GetComponent<dayNightControllerScript>().isNight)
        {
            Set("isSwinging", true);
            Set("canDealDamage", false);
        }
    }

    // Retrieve the boolean value of an Animator parameter
    bool Get(string parameterName)
    {
        return hammerAnimator.GetBool(parameterName);
    }

    // Set the boolean value of an Animator parameter
    void Set(string parameterName, bool value)
    {
        hammerAnimator.SetBool(parameterName, value);
    }
}
