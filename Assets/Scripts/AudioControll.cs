using UnityEngine;
using System.Collections;

public class AudioControll : MonoBehaviour {

    public static AudioControll instance;

    public AudioSource audioStart;
    public AudioSource audioIngame;
    public AudioSource audioBom;
    public AudioSource audioButton;

    public static bool music = true;
    public static bool sfx = true;

    void Awake()
    {
        instance = this;
        audioStart = GetComponents<AudioSource>()[0];
        audioIngame = GetComponents<AudioSource>() [ 1 ];
        audioBom = GetComponents<AudioSource>() [ 2 ];
        audioButton = GetComponents<AudioSource>() [ 3 ];
        if(music)
        {
            audioStart.volume = 1;
            audioIngame.volume = 1;
        }
        else
        {
            audioStart.volume = 0;
            audioIngame.volume = 0;
        }

        if(sfx)
        {
            audioBom.volume = 1;
            audioButton.volume = 1;
        }
        else
        {
            audioBom.volume = 0;
            audioButton.volume = 0;
        }
    }
}
