using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ChangeVolMusique : MonoBehaviour
{
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio.volume = SC_AudioMusique.vol;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
