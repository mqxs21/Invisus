using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class FoodSpawnerControllerScript : MonoBehaviour
{
    private dayNightControllerScript dayNightController;
    private bool shouldUpdateDay;
    [SerializeField] private float spawnFoodYLoc;
    [SerializeField] private GameObject foodPreFab;

    private WaveControllerScript waveControl;
    void Start()
    {
        shouldUpdateDay = false;
        dayNightController = GameObject.Find("DayNightController").GetComponent<dayNightControllerScript>();
        waveControl = GameObject.Find("WaveController").GetComponent<WaveControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dayNightController.isNight && shouldUpdateDay)
        {
            //spawn food
            for (int i = 0; i < waveControl.waveNumberPublic; i++)
            {
                float randOnetoThree = UnityEngine.Random.Range(1,3);
                if (randOnetoThree >=1 && randOnetoThree <=2)
                {
                    float randomX = UnityEngine.Random.Range(-92,-105);
                float randomZ = UnityEngine.Random.Range(-13,0);
                Vector3 spawnFoodLoc = new Vector3(randomX,spawnFoodYLoc,randomZ);
                Instantiate(foodPreFab,spawnFoodLoc,Quaternion.identity);
                }
                
            }
            
            shouldUpdateDay = false;
        }
        if (!dayNightController.isNight)
        {
            shouldUpdateDay = true;
        }
    }
}
