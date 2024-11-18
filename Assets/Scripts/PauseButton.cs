using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseButton : MonoBehaviour
{
    public InputActionReference trigger;
    public GameObject restartButton; 
    public GameObject quitButton;
    private bool isMenuActive = false;

    void Start()
    {
         restartButton.SetActive(false);
        quitButton.SetActive(false);
    }
    void Update()
    {
        if (trigger.action.ReadValue<float>() > 0.0f)
        {
            ToggleButtons(true);  // Show buttons when trigger is pressed
        }
        else
        {
            ToggleButtons(false);  // Hide buttons when trigger is released
        }
    }
    public void ToggleButtons(bool show)
    {
        if (show && !isMenuActive)
        {
            restartButton.SetActive(true);
            quitButton.SetActive(true);
            isMenuActive = true;
        }
        else if (!show && isMenuActive)
        {
            restartButton.SetActive(false);
            quitButton.SetActive(false);
            isMenuActive = false;
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();  // Will only work in the build
        
    }
}
