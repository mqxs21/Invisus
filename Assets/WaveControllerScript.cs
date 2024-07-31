using TMPro;
using UnityEngine;
using System.Collections;

public class WaveControllerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveNoText;
    bool shouldUpdate = true;
    
    void Start()
    {
        waveNoText.text = "0";
       dayNightControllerScript dayNightController = GameObject.Find("DayNightController").GetComponent<dayNightControllerScript>();
        if (dayNightController != null && dayNightController.isNight)
        {
            // Parse the current wave number from the text
            int waveNo = int.Parse(waveNoText.text);

            // Increment the wave number
            waveNo+=0;

            // Update the text with the new wave number
            waveNoText.text = waveNo.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        dayNightControllerScript dayNightController = GameObject.Find("DayNightController").GetComponent<dayNightControllerScript>();
        if (shouldUpdate && dayNightController.isNight)
        {
            Debug.Log("update text");
            shouldUpdate = false;
            int waveNo = int.Parse(waveNoText.text);
            waveNo++;
            waveNoText.text = waveNo.ToString();
            GetComponent<Animator>().SetBool("showTextWave",true);
            StartCoroutine(waitTextFalse());
        }
        if (!dayNightController.isNight)
        {
            shouldUpdate = true;
        }
    }
    private IEnumerator waitTextFalse(){
        yield return new WaitForSeconds(1f);
        GetComponent<Animator>().SetBool("showTextWave",false);
    }
    

}
