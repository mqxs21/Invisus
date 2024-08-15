using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLooking : MonoBehaviour
{
   /* public Transform playerCamera; // Reference to the player's camera
    public EnemyAI enemyAI; // Reference to the EnemyAI script
    public float maxDistance = 100f; // Maximum distance to check for line of sight
    public Vector3 boxHalfExtents = new Vector3(0.5f, 0.5f, 0.5f); // Half the size of the box in each dimension

    void Start()
    {
        if (!playerCamera)
        {
            playerCamera = Camera.main.transform; // Assign the main camera if not set
        }
        
        if (!enemyAI)
        {
            enemyAI = GetComponentInParent<EnemyAI>(); // Get the EnemyAI component from the parent object
        }
    }

    void Update()
    {
        Vector3 direction = transform.position - playerCamera.position;
        Ray ray = new Ray(playerCamera.position, direction);
        RaycastHit hit;

        // Perform the BoxCast
        if (Physics.BoxCast(playerCamera.position, boxHalfExtents, direction, out hit, Quaternion.identity, maxDistance))
        {
            if (hit.transform == transform)
            {
                enemyAI.isLooking = true; // The player is looking at this object
            }
            else
            {
                enemyAI.isLooking = false; // The player is not looking at this object
            }
        }
        else
        {
            enemyAI.isLooking = false; // The player is not looking at this object
        }
    }

    // Draw Gizmos to visualize the BoxCast
    void OnDrawGizmos()
    {
        if (playerCamera != null)
        {
            Gizmos.color = Color.red;

            // Draw the box cast in the scene view
            Gizmos.matrix = Matrix4x4.TRS(playerCamera.position, Quaternion.LookRotation(transform.position - playerCamera.position), Vector3.one);
            Gizmos.DrawWireCube(Vector3.forward * maxDistance / 2, boxHalfExtents * 2);
        }
    }*/
}
