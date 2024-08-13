using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class dayNightControllerScript : MonoBehaviour
{
    public bool isNight;
    private Light directionalLight;
    private Volume globalVolume;
    private Vignette vignette;

    private HungerControllerScript hungerController;
    [SerializeField] Color initialColor = Color.black;
    [SerializeField] Color targetColor = Color.red;

    [SerializeField] private float dayNightSeconds;

    private float hungerPercent;

    WaveControllerScript waveController;

    private float waveNo;

    void Start()
    {
        // Cache references to avoid calling Find every frame
        hungerController = GameObject.Find("HungerController").GetComponent<HungerControllerScript>();
        directionalLight = GameObject.Find("Directional Light").GetComponent<Light>();
        globalVolume = GameObject.Find("Global Volume").GetComponent<Volume>();

        if (globalVolume.profile.TryGet(out Vignette vignetteComponent))
        {
            vignette = vignetteComponent;
        }
        else
        {
            Debug.LogError("Vignette component not found in the Global Volume profile.");
        }
        waveController = GameObject.Find("WaveController").GetComponent<WaveControllerScript>();
        StartCoroutine(dayNightCycle(dayNightSeconds));
    }

    void Update()
    {
        hungerPercent = hungerController.currentHunger / hungerController.maxHunger;
        waveNo = waveController.waveNumberPublic;
        UpdateVignetteColor();
        Camera.main.backgroundColor = isNight ? Color.black : Color.grey;

        if (Input.GetKeyDown(KeyCode.F))
        {
            isNight = !isNight;
        }

        if (isNight)
        {
            GameObject.Find("SledgeHammer").GetComponent<Renderer>().enabled =false;
            
            if (directionalLight != null)
                directionalLight.enabled = false;

            if (vignette != null)
                vignette.intensity.value = 0.7f;
        }
        else
        {
            GameObject.Find("SledgeHammer").GetComponent<Renderer>().enabled =true;
            GameObject.Find("SledgeHammer").SetActive(true);
            if (directionalLight != null)
                directionalLight.enabled = true;

            if (vignette != null)
                vignette.intensity.value = 0.272f;
        }
    }
    void UpdateVignetteColor(){
        if (vignette == null || hungerController == null)
            return;

        

        // If hunger decreases, transition to red; if it increases, transition back quickly
        Color targetVignetteColor = Color.Lerp(initialColor, targetColor, 1 - hungerPercent);
        vignette.color.value = targetVignetteColor;

    }
    private IEnumerator dayNightCycle(float dayNightSeconds){
        bool end = false;
        while (!end)
        {
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(dayNightSeconds/3);
                Debug.Log(i);
                if (!isNight && GameObject.FindGameObjectWithTag("Food") == null)
                {
                    Debug.Log("Detecting No food");
                    isNight = true;
                    end = true;
                    i=3;
                    StartCoroutine(dayNightCycle(dayNightSeconds));
                }
                else{
                    Debug.Log(GameObject.FindGameObjectWithTag("Food") + "is still in scene");
                }
            }
            if (!end)
            {
                isNight = !isNight;
            }
            
        }
        
    }
}
