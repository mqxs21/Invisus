using UnityEngine;

public class VisibilityChecker : MonoBehaviour
{
    private Renderer objectRenderer;
    public bool cameraCanSee;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        {
        cameraCanSee = objectRenderer.isVisible;
    }
    }
}
