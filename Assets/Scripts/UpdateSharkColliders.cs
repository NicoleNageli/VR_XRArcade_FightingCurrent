using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSharksColliders : MonoBehaviour
{
    // LayerMask to specify which layer the sharks are on
    public LayerMask grappleLayer;

    void Start()
    {
        // Find all sharks with the tag "GrappleTarget" and on the correct layer
        GameObject[] sharks = GameObject.FindGameObjectsWithTag("GrappleTarget");

        // Loop through all sharks and check their layer
        foreach (GameObject shark in sharks)
        {
            // Check if the shark is on the correct layer
            if (((1 << shark.layer) & grappleLayer) != 0)
            {
                UpdateCollider(shark);
            }
        }
    }

    void UpdateCollider(GameObject shark)
    {
        // Update the shark's collider to be a BoxCollider
        Collider currentCollider = shark.GetComponent<Collider>();
        if (currentCollider != null)
        {
            Destroy(currentCollider); // Remove existing collider
        }

        // Add a BoxCollider to replace the old collider
        BoxCollider boxCollider = shark.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(1, 1, 1);  // Adjust the size as needed
        boxCollider.center = Vector3.zero;  // Adjust the center if needed
    }
}
