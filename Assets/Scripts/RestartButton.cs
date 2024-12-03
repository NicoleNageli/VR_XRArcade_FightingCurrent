/*using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class RestartButton : MonoBehaviour
{
    private XRRayInteractor rayInteractor;

    void Start()
    {
        // Find the ray interactor component on the controller (it may vary depending on your setup)
        rayInteractor = FindObjectOfType<XRRayInteractor>();
    }

    void OnTriggerEnter(Collider other)
    {
        // If the button is clicked (ray intersects with the button collider)
        if (other.CompareTag("Player") && rayInteractor.selectPressed)
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
*/