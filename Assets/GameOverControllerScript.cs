using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOverControllerScript : MonoBehaviour
{
    HungerControllerScript hungerControllerScript;
    void Start()
    {
        if (GameObject.Find("HungerController") != null) 
        {
            hungerControllerScript = GameObject.Find("HungerController").GetComponent<HungerControllerScript>();
        }else{
            Debug.Log("HungerController Null in GameOverControllerScript");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("HungerController") != null)
        {
            if (hungerControllerScript.death)
            {
                GameOver();
            }
        }
        
    }
    void GameOver(){
        SceneManager.LoadScene("DeathScreen");
        Debug.Log("Death");
    }
}
