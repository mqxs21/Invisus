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

    [SerializeField] private float randomLocationXHigherBound = -90;
    [SerializeField] private float randomLocationXLowerBound = -115;

    [SerializeField] private float randomLocationZHigherBound = 0;
    [SerializeField] private float randomLocationZLowerBound = -13;


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
                float randomX = UnityEngine.Random.Range(randomLocationXHigherBound,randomLocationXLowerBound);
                float randomZ = UnityEngine.Random.Range(randomLocationZLowerBound,randomLocationZHigherBound);
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
    public void spawnFood(float amountOfFood){
        for (int j = 0; j < amountOfFood; j++)
        {
            float randomX = UnityEngine.Random.Range(randomLocationXHigherBound,randomLocationXLowerBound);
            float randomZ = UnityEngine.Random.Range(randomLocationZLowerBound,randomLocationZHigherBound);
            Vector3 spawnFoodLoc = new Vector3(randomX,spawnFoodYLoc,randomZ);
            Instantiate(foodPreFab,spawnFoodLoc,Quaternion.identity);
        }
    }
}
