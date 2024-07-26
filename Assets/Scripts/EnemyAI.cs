using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class EnemyAI : MonoBehaviour
{
    private GameObject dayNight;
    private bool canChasePlayer;
    public NavMeshAgent agent;

    public bool canBeHit;

    public bool isDead = false;
    public Renderer rend;
    public bool isVisible;
    public Transform player;

    void Awake(){
        Cursor.visible = false;
        
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rend = GetComponent<Renderer>();
        dayNight = GameObject.Find("DayNightController");
        player = GameObject.Find("FirstPersonController").transform;
        agent = GetComponent<NavMeshAgent>();

        // Set a reasonable stopping distance
        agent.stoppingDistance = 1.5f; // Adjust this value as needed
    }

    void Update()
    {
        if (isDead && !dayNight.GetComponent<dayNightControllerScript>().isNight)
        {
            Destroy(gameObject);
        }
        if (dayNight.GetComponent<dayNightControllerScript>().isNight)
        {
            canBeHit = false;
            GameObject.Find("Directional Light").GetComponent<Light>().enabled = false;

            if (!rend.isVisible)
            {
                agent.enabled = true;
                canChasePlayer = true;
               
            }
            else
            {
                agent.enabled = false;
                canChasePlayer = false;
                 agent.speed = UnityEngine.Random.Range(9,14);
            }
        }
        else
        {
            canBeHit = true;
            agent.enabled = false;
            canChasePlayer = false;
            GameObject.Find("Directional Light").GetComponent<Light>().enabled = true;
        }

        if (canChasePlayer)
        {
            agent.destination = player.position;
        }

        if(Vector3.Distance(transform.position, player.position)<1.75 && dayNight.GetComponent<dayNightControllerScript>().isNight && !rend.isVisible){
            Debug.Log("kill");
            SceneManager.LoadScene("DeathScreen");
        }
    }

    private void speedChanger(){
        agent.speed = UnityEngine.Random.Range(9,14);
    }
    
}
