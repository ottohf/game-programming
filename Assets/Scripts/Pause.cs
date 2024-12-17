using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public bool isPaused;
    public Button resumeButton;
    public GameObject pauseMenu;

    void Awake()
    {
        isPaused = false;
        resumeButton.onClick.AddListener(OnResumePressed);
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseMenu.SetActive(isPaused);

            if (isPaused)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void OnResumePressed()
    {
        Debug.Log("Resume Button Pressed");
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}