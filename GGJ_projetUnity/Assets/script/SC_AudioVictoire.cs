using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SC_AudioVictoire : MonoBehaviour
{
    public float volume;
    public float pitch;

    private AudioSource[] source;
    
    void Awake() 
    {
        source = GetComponents<AudioSource>();
    }

    void Start()
    {
        lancerAudio();
    }

    public void lancerAudio()
    {
        for(int i = 0;i<source.Length;i++) {
            source[i].Play();
            source[i].volume = volume;
        }
        
        //Debug.Log("jouer le son de la fete");
    }
}
