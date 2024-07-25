
using Unity.VisualScripting;
using UnityEngine;

public class dayNightControllerScript : MonoBehaviour
{
    public bool isNight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.backgroundColor = isNight ? Color.black : Color.grey;
        if (Input.GetKeyDown(KeyCode.F))
        {
            isNight = !isNight;
        }
    }
}
