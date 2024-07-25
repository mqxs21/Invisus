using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private GameObject dayNight;
    private bool canChasePlayer;
    public NavMeshAgent agent;

    public Renderer rend;
    public bool isVisible;
    public Transform player;

    void Start()
    {
        rend = GetComponent<Renderer>();
        dayNight = GameObject.Find("DayNightController");
        player = GameObject.Find("FirstPersonController").transform;
        agent = GetComponent<NavMeshAgent>();

        // Set a reasonable stopping distance
        agent.stoppingDistance = 1.5f; // Adjust this value as needed
    }

    void Update()
    {
        if (dayNight.GetComponent<dayNightControllerScript>().isNight)
        {
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
            }
        }
        else
        {
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
        }
    }

    
}
