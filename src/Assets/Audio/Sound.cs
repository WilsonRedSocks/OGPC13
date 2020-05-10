using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    //create the name
    public string name;

    //create the clip
    public AudioClip clip;

    //create the volume and pitch
    [Range(0f,1f)] public float volume;
    [Range(0.1f,3f)] public float pitch;

    //create the audio source
    [HideInInspector]
    public AudioSource source;
}
