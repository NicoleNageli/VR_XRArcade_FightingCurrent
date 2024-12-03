using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign your projectile prefab in the inspector
    public Transform shootPoint; // Assign the shoot point (where the projectile is spawned)
    public InputActionReference trigger; // Assign your trigger action reference
    public float launchForce = 10f; // Adjustable launch force

    private GameObject currentProjectile;

    void Update()
    {
        if (trigger == null)
        {
            Debug.LogError("Trigger is not assigned!");
            return;
        }

        float triggerValue = trigger.action.ReadValue<float>();
        
        if (triggerValue > 0.0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (currentProjectile != null) return; // Prevent shooting if there's already a projectile

        // Instantiate the projectile
        currentProjectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = currentProjectile.GetComponent<Rigidbody>();
        
        if (rb != null)
        {
            // Apply force in the direction the shootPoint is facing
            rb.AddForce(shootPoint.forward * launchForce, ForceMode.Impulse); // Using launchForce for more impact
        }
        
        StartCoroutine(TeleportToProjectile());
    }

    IEnumerator TeleportToProjectile()
    {
        yield return new WaitForSeconds(1f); // Wait for the projectile to land
        
        if (currentProjectile != null)
        {
            // Teleport the player to the projectile's position
            transform.position = currentProjectile.transform.position;
            Destroy(currentProjectile); // Destroy the projectile after teleporting
            currentProjectile = null; // Reset the current projectile
        }
    }
}
