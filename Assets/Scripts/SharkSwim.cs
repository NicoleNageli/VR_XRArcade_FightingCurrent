using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSwim : MonoBehaviour
{
    public float bobbingHeight = 0.5f;
    public float bobbingSpeed = 2f;
    public float sideToSideDistance = 2f;
    public float sideToSideSpeed = 1f;
    public bool swimSideToSide = true; // Toggle for side-to-side vs. back-and-forth movement
    
    private Vector3 initialPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Bobbing motion (up and down)
        float newY = initialPosition.y + Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;

        // Side-to-side movement (local right direction based on the object's current rotation)
        float offset = Mathf.Sin(Time.time * sideToSideSpeed) * sideToSideDistance;

        Vector3 newPosition;

        if (swimSideToSide)
        {
            // Move side-to-side using the object's local right direction
            newPosition = initialPosition + transform.right * offset;
        }
        else
        {
            // Move forward and backward using the object's local forward direction
            newPosition = initialPosition + transform.forward * offset;
        }

        // Apply bobbing and movement
        newPosition.y = newY;
        transform.position = newPosition;
    }
}
