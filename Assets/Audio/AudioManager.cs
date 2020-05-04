using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //create the sounds
    public Sound[] soundsmain;
    public AudioSource audiomain;
    public AudioSource seedaudio;
    public AudioSource footstepaudio;
    public Transform player;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound i in soundsmain)
        {
            i.source = gameObject.AddComponent<AudioSource>();
            i.source.clip = i.clip;
            i.source.pitch = i.pitch;
            i.source.volume = i.volume;
        }
        audiomain.loop = true;
        footstepaudio.loop = true;
    }

    void start()
    {
        audiomain.clip = soundsmain[0].clip;
        audiomain.Play();
        footstepaudio.clip = soundsmain[3].clip;
    }

    // Update is called once per frame
    bool one_soundtrack = false;
    bool one_footstep = false;
    Vector3 temp = Vector3.zero;
    void Update()
    {
        if(Collectibles.seedscollected >= 9 && !one_soundtrack)
        {
            audiomain.clip = soundsmain[1].clip;
            audiomain.Play();
            one_soundtrack = true;
        }
        if(player.position != temp && !one_footstep)
        {
            one_footstep = true;
            footstepaudio.Play();
        }
        else
        {
            footstepaudio.Stop();
            one_footstep = false;
        }
        temp = player.position;
    }
}
