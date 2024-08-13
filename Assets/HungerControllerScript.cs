using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HungerControllerScript : MonoBehaviour
{
    [SerializeField] private float dicreaseRateSeconds;
    public float maxHunger = 100f;  // Maximum hunger value
    public float currentHunger;     // Current hunger value
    public float startingHungerDecreaseRate = 1f; // How much hunger decreases per second
    public float currentHungerDecreaseRate = 1f; // How much hunger decreases per second   
    [SerializeField] private bool resetExpoGrowth;
    [SerializeField] private int growth;
    public TextMeshProUGUI hungerText;         // Reference to the UI Text component
    [SerializeField] private RectTransform hungerUIInside;
    
    private float maxXSize = 403.65f;

    public bool death = false;

    public UnityEvent onGameOver;
    
    void Start()
    {
        currentHungerDecreaseRate = startingHungerDecreaseRate;
        currentHunger = maxHunger;  // Initialize hunger to maximum
        StartCoroutine(DecreaseHunger()); // Start the coroutine to decrease hunger
        maxXSize = 0.4f;
        death = false;
    }

    void Update()
    {
        
        UpdateHungerText();
        UpdateHungerBar(currentHunger,maxHunger);  // Update the UI text each frame
        if (resetExpoGrowth)
        {
            currentHungerDecreaseRate = startingHungerDecreaseRate;
            resetExpoGrowth = false;
            growth = 0;
        }
        if (currentHunger<=0)
        {
            onGameOver.Invoke();
            death = true;
        }
    }

    IEnumerator DecreaseHunger()
    {
        while (currentHunger > 0)
        {
            yield return new WaitForSeconds(dicreaseRateSeconds);  // Wait for 1 second
            currentHunger -= currentHungerDecreaseRate;  // Decrease hunger
            currentHungerDecreaseRate += 0.0015f;
            if (currentHunger < 0)
            {
                currentHunger = 0;  // Ensure hunger doesn't go below 0
            }
        }
        // Handle what happens when hunger reaches zero, if needed
    }

    void UpdateHungerText()
    {
        hungerText.text = currentHunger.ToString("0") + "%";  // Update the UI text
    }

    public void IncreaseHunger(float increaseAmount){
        resetExpoGrowth = true;
        if (currentHunger+increaseAmount >100)
        {
            currentHunger=100;
        }else{
            currentHunger += increaseAmount;
        }
        
    }
    
    // Call this method to update the hunger bar
     public void UpdateHungerBar(float currentHunger, float maxHunger)
{
    // Calculate the target hunger percentage (0 to 1)
    float targetHungerPercent = currentHunger / maxHunger;
    Vector3 currentScale = hungerUIInside.localScale;
    if (targetHungerPercent <= 0.3)
    {
        GameObject.Find("FoodSpawnerController").GetComponent<FoodSpawnerControllerScript>().spawnFood(2f);
    }
   
    float lerpSpeed = 5f; 
    float newScaleX = Mathf.Lerp(currentScale.x, targetHungerPercent, Time.deltaTime * lerpSpeed);
    hungerUIInside.localScale = new Vector3(newScaleX, 1f, 1f);
}

}
