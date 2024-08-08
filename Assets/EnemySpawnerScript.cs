using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] private int waveNumberPublic;

    [SerializeField] private float minimumRaidusCanSpawn;
    [SerializeField] private bool shouldUpdate;

    [SerializeField] private GameObject enemyPreFab;

    private bool spawnSomething = false;
    void Start()
    {
        waveNumberPublic = GameObject.Find("WaveController").GetComponent<WaveControllerScript>().waveNumberPublic;
    }

    // Update is called once per frame
    void Update()
    {
        waveNumberPublic = GameObject.Find("WaveController").GetComponent<WaveControllerScript>().waveNumberPublic;
        dayNightControllerScript dayNightController = GameObject.Find("DayNightController").GetComponent<dayNightControllerScript>();
        if (shouldUpdate && dayNightController.isNight)
        {
            shouldUpdate = false;
            bool spawnSomething = false;
            for (int i = 0; i <= 23; i++)
            {
                int randomValue = UnityEngine.Random.Range(1,35);
                //Debug.Log("rolling Number" + randomValue.ToString());
                if (randomValue <= waveNumberPublic)
                {
                    Debug.Log("spawning enemy at " + i.ToString());
                    GameObject spawner = GameObject.Find("EnemySpawnerLocation ("+ i.ToString() + ")");
                    Vector3 enemySpawnLoc = spawner.transform.position;
                    enemySpawnLoc.y = 4.668022f;
                    RaycastHit Hit;
                    /*if (Physics.SphereCast(enemySpawnLoc,minimumRaidusCanSpawn,out Hit, ))
                    {
                        
                    }*/
                    spawnSomething = true;
                    Instantiate(enemyPreFab,enemySpawnLoc,Quaternion.identity);
                }
            }
            Debug.Log("spawnSomething: " + spawnSomething);
            if (!spawnSomething)
            {
                Debug.Log("backup spawn");
                for (int i = 0; i < waveNumberPublic; i++)
                {
                    int rnd = UnityEngine.Random.Range(0,23);
                    GameObject spawner = GameObject.Find("EnemySpawnerLocation ("+ rnd.ToString() + ")");
                    Vector3 enemySpawnLoc = spawner.transform.position;
                    enemySpawnLoc.y = 4.668022f;
                    Instantiate(enemyPreFab,enemySpawnLoc,Quaternion.identity);
                }
                

            }
        }
        if (!dayNightController.isNight)
        {
            spawnSomething = false;
            shouldUpdate = true;
        }
    }
}
