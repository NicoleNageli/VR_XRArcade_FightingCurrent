using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GrapplingHook : MonoBehaviour
{
    public InputActionReference trigger;
    public LayerMask grappleLayer;  // Layer for grapple-able objects
    public Transform handTransform;  // The VR controller or hand position
    public float pullSpeed = 10f;    // Speed at which player is pulled
    public GameObject player;  // Reference to the player object (with the CharacterController)

    private LineRenderer grappleLine;  // Visualizing the grapple line
    private bool isGrappling = false;  // Is the player currently grappling?
    private Vector3 grapplePoint;      // The point where the player is grappling to

    private CharacterController characterController;  // Player controller to move

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GrapplingHook Start method called.");
        // Get the CharacterController from the player object
        if (player != null)
        {
            characterController = player.GetComponent<CharacterController>();
        }
        else
        {
            Debug.LogError("Player object is not assigned.");
        }

        // Reference the existing LineRenderer instead of adding a new one
        grappleLine = GetComponent<LineRenderer>();
        if (grappleLine == null)
        {
            Debug.LogError("LineRenderer not found on the GameObject. Please add a LineRenderer component.");
            return; // Exit if there's no LineRenderer
        }

        grappleLine.enabled = false;
        grappleLine.startWidth = 0.02f;
        grappleLine.endWidth = 0.02f;
        grappleLine.material = new Material(Shader.Find("Unlit/Color"));
        grappleLine.material.color = Color.green; // Set to a visible color
        Debug.Log("GrapplingHook initialized.");

    }

    // Update is called once per frame
    void Update()
    {

        // Log trigger input values
        float triggerValue = trigger.action.ReadValue<float>();
        Debug.Log("Trigger value: " + triggerValue);

        // Check if the player is grappling
        if (isGrappling)
        {
            Debug.Log("Player is currently grappling.");
            // Pull the player toward the grapple point
            Vector3 pullDirection = (grapplePoint - transform.position).normalized;
            characterController.Move(pullDirection * pullSpeed * Time.deltaTime);

            // Optionally, draw the line from the hand to the grapple point
            grappleLine.SetPosition(0, handTransform.position);
            grappleLine.SetPosition(1, grapplePoint);

            // Stop grappling if close to the target
            if (Vector3.Distance(transform.position, grapplePoint) < 1f)
            {
                StopGrapple();
            }
        }

        // player input
        if (trigger.action.ReadValue<float>() > 0.0 && !isGrappling)
        {
            Debug.Log("Trigger pressed. Attempting to grapple.");
            AttemptGrapple();
        }
    }
    void AttemptGrapple()
    {
        RaycastHit hit;

        // Cast a ray from the hand/controller forward
        Debug.Log("Casting ray from handTransform.");
        if (Physics.Raycast(handTransform.position, handTransform.forward, out hit, 100f, grappleLayer))
        {
            Debug.Log("Raycast hit: " + hit.collider.name);
            if (hit.collider.CompareTag("GrappleTarget"))
            {
                Debug.Log("Grapple target hit: " + hit.collider.name);
                // Start grappling if a valid target is hit
                isGrappling = true;
                grapplePoint = hit.point;
                // Disable collision with the environment temporarily
                if (characterController != null)
                {
                    characterController.detectCollisions = false;
                }

                // Enable the grapple line (optional)
                grappleLine.enabled = true;
            }
            else
            {
                Debug.Log("Raycast hit something, but it's not a grapple target.");
            }
        }
        else
        {
            Debug.Log("Raycast did not hit anything.");
        }
    }

    public void StopGrapple()
    {
        // Stop grappling and reset
        Debug.Log("Stopping grapple.");
        isGrappling = false;
        grappleLine.enabled = false;
        grapplePoint = Vector3.zero;
    }
}
