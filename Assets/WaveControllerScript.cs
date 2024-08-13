using TMPro;
using UnityEngine;
using System.Collections;

public class WaveControllerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveNoText;
    bool shouldUpdate = true;
    public int waveNumberPublic;
    void Start()
    {
        waveNoText.text = "0";
        waveNumberPublic = 0;
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
            shouldUpdate = false;
            int waveNo = int.Parse(waveNoText.text);
            waveNo++;
            waveNumberPublic = waveNo;
            if (waveNumberPublic == 1)
            {
                waveNoText.text = waveNo.ToString();
            }else{
                waveNoText.text = waveNo.ToString();
            }
            if (waveNumberPublic==1)
            {
                
            }else{
            GetComponent<Animator>().SetBool("showTextWave",true);
            StartCoroutine(waitTextFalse());
            }
            
        }
        if (!dayNightController.isNight)
        {
            shouldUpdate = true;
        }

    }
    private IEnumerator waitTextFalse(){
        if (waveNumberPublic == 1)
        {
            yield return new WaitForSeconds(3f);
        }else{
            yield return new WaitForSeconds(1f);
        }
        
        GetComponent<Animator>().SetBool("showTextWave",false);
    }
    

}
