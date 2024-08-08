using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HungerControllerScript : MonoBehaviour
{
    public float maxHunger = 100f;  // Maximum hunger value
    public float currentHunger;     // Current hunger value
    public float startingHungerDecreaseRate = 1f; // How much hunger decreases per second
    public float currentHungerDecreaseRate = 1f; // How much hunger decreases per second   
    [SerializeField] private bool resetExpoGrowth;
    [SerializeField] private int growth;
    public TextMeshProUGUI hungerText;         // Reference to the UI Text component

    void Start()
    {
        currentHungerDecreaseRate = startingHungerDecreaseRate;
        currentHunger = maxHunger;  // Initialize hunger to maximum
        StartCoroutine(DecreaseHunger()); // Start the coroutine to decrease hunger
    }

    void Update()
    {
        UpdateHungerText();  // Update the UI text each frame
        if (resetExpoGrowth)
        {
            currentHungerDecreaseRate = startingHungerDecreaseRate;
            resetExpoGrowth = false;
            growth = 0;
        }
    }

    IEnumerator DecreaseHunger()
    {
        while (currentHunger > 0)
        {
            yield return new WaitForSeconds(1f);  // Wait for 1 second
            currentHunger -= currentHungerDecreaseRate;  // Decrease hunger
            currentHungerDecreaseRate += 0.2f;
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
}
