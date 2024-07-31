using UnityEngine;

public class BoxCastLogger : MonoBehaviour
{
    public Camera playerCamera; // Assign your player camera in the inspector
    public Vector3 boxSize = new Vector3(1, 1, 1); // Size of the box
    public float maxDistance = 100f; // Maximum distance for the box cast

    void Update()
    {
        // Get the direction the camera is facing
        Vector3 direction = playerCamera.transform.forward;

        // Perform the box cast
        RaycastHit hit;
        bool hasHit = Physics.BoxCast(playerCamera.transform.position, boxSize/2,direction, out hit, playerCamera.transform.rotation, maxDistance);

        // Check if something was hit
        if (hasHit && hit.collider.CompareTag("Enemy"))
        {
            //Debug.Log("Hit: " + hit.collider.name);
        }
        else
        {
            //Debug.Log("Nothing hit");
        }
    }

    // Draw the box cast in the Scene view for debugging
    void OnDrawGizmos()
    {
        if (playerCamera != null)
        {
            Vector3 direction = playerCamera.transform.forward;
            Gizmos.color = Color.red;
            Gizmos.matrix = Matrix4x4.TRS(playerCamera.transform.position, playerCamera.transform.rotation, Vector3.one);
            Gizmos.DrawWireCube(Vector3.zero + direction * maxDistance / 2, boxSize);
        }
    }
}
