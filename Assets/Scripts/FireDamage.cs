using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireDamage : MonoBehaviour
{
    [SerializeField] AudioSource fireDeath;
    public Transform PlayerStartPoint;
    public GrapplingHook grapplingHook; 
    public float respawnDelay = 3f; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player hit fire, respawn");
            fireDeath.Play();
            //RespawnPlayer(other.gameObject);
            StartCoroutine(RespawnAfterDelay());
        }
    }
     private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);  // Wait for the delay
        RestartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

/*
    private void RespawnPlayer(GameObject player)
    {
        
        
        CharacterController controller = player.GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false;
        }
        if (grapplingHook != null)
        {
            grapplingHook.StopGrapple();  // Ensure grappling stops
        }

        // Teleport the player to the start point
        player.transform.position = PlayerStartPoint.position;
        player.transform.rotation = PlayerStartPoint.rotation;

        // Re-enable CharacterController
        if (controller != null)
        {
            controller.enabled = true;
        }
        
    }
*/
}
