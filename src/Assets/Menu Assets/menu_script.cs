using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;
using System.Threading;

public class menu_script : MonoBehaviour
{
    public GameObject settingscanvas;
    public GameObject pausecanvas;
    public AudioMixer master;
    public Slider masterslider;
    public Slider musicslider;
    public Slider effectsslider;
    public Texture2D crosshair;


    public void open()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void resume()
    {
        pausecanvas.SetActive(false);
        settingscanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(crosshair, Vector2.zero, CursorMode.ForceSoftware);
        Time.timeScale = 1;
    }

    public void settings()
    {
        pausecanvas.SetActive(false);
        settingscanvas.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }

    public void back()
    {
        settingscanvas.SetActive(false);
        pausecanvas.SetActive(true);
    }

    public void setmasterlevel(float level)
    {
        master.SetFloat("master", level);
    }

    public void seteffectslevel(float level)
    {
        master.SetFloat("effects", level);
    }

    public void setmusiclevel(float level)
    {
        master.SetFloat("music", level);
    }

    public void quit()
    {
        Application.Quit();
    }
}
