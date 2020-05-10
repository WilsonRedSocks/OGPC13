using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //create the sounds
    public Sound[] soundsmain;
    public AudioSource audiomain;
    public AudioSource seedaudio;
    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        gameObject.tag = "audio";
        DontDestroyOnLoad(transform.root.gameObject);
        foreach(Sound i in soundsmain)
        {
            i.source = gameObject.AddComponent<AudioSource>();
            i.source.clip = i.clip;
            i.source.pitch = i.pitch;
            i.source.volume = i.volume;
        }
        audiomain.clip = soundsmain[0].clip;
        audiomain.Play();
    }

    // Update is called once per frame
    bool one_soundtrack = false;
    void Update()
    {
        if(Collectibles.seedscollected >= 9 && !one_soundtrack)
        {
            audiomain.clip = soundsmain[1].clip;
            audiomain.Play();
            one_soundtrack = true;
        }
    }
}
