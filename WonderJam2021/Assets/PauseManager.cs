using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static bool m_gameIsPaused;
    public GameObject m_pauseMenuCanvas;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        // to get main camera when the scene changes
        this.gameObject.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").gameObject.GetComponent<Camera>();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            m_gameIsPaused = !m_gameIsPaused;
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (m_gameIsPaused)
        {
            PauseGame();
        }
        else
        {
            UnpauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        m_pauseMenuCanvas.GetComponent<Canvas>().enabled = true;
        m_gameIsPaused = true;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        m_pauseMenuCanvas.GetComponent<Canvas>().enabled = false;
        m_gameIsPaused = false;
    }
    public void goToMenu()
    {
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("Ghost"));
        Destroy(GameObject.Find("Rope"));
        Destroy(GameObject.Find("CameraManager"));
        Destroy(GameObject.Find("AudioManager"));
        Destroy(GameObject.Find("GameUI"));
        Debug.Log("Open MainMenu");

        UnpauseGame();

        SceneManager.LoadScene("SceneMainMenu");
        Destroy(this.gameObject);
    }

}
