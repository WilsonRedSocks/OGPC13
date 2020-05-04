using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class animate_text : MonoBehaviour
{
    public string text;
    public Text textbox;
    public float sleepdelay;
    public AudioSource source;

    // Update is called once per frame
    float i;
    int j;
    bool animate = true;
    void Update()
    {
        i += Time.deltaTime;
        if(i >= sleepdelay && animate)
        {
            j++;
            textbox.text = text.Substring(0, j);
            i = 0;
            source.Play();
            if(j==text.Length)
            {
                animate = false;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("main_scene");
        }
    }
}
