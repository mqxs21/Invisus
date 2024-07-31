using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class dayNightControllerScript : MonoBehaviour
{
    public bool isNight;
    private Light directionalLight;
    private Volume globalVolume;
    private Vignette vignette;

    void Start()
    {
        // Cache references to avoid calling Find every frame
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
    }

    void Update()
    {
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
}
