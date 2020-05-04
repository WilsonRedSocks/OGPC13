using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_script : MonoBehaviour
{
    public GameObject settingscanvas;
    public GameObject pausecanvas;
    public GameObject hudcanvas;
    public Texture2D crosshair;

    public void resume()
    {
        pausecanvas.SetActive(false);
        settingscanvas.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(crosshair, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void settings()
    {
        pausecanvas.SetActive(false);
        settingscanvas.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
