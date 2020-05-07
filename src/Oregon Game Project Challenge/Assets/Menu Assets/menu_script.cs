using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;

public class menu_script : MonoBehaviour
{
    public GameObject settingscanvas;
    public GameObject pausecanvas;
    public AudioMixer master;
    public Slider masterslider;
    public Slider musicslider;
    public Slider effectsslider;
    public Texture2D pointer;


    void Awake()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
        float temp;
        master.GetFloat("master", out temp);
        masterslider.value = temp;
        Debug.Log(temp);
        master.GetFloat("music", out temp);
        musicslider.value = temp;
        master.GetFloat("effects", out temp);
        effectsslider.value = temp;
    }

    public void resume()
    {
        SceneManager.LoadScene(1);
        pausecanvas.SetActive(true);
        settingscanvas.SetActive(false);
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
