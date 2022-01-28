using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_AudioMusique : MonoBehaviour
{
    public Slider slid;
    public static float vol = 0.5f;
    // Start is called before the first frame update
    void Awake()
    {
        slid.value = vol;
    }

    private void Update()
    {
    }

    public void majVol(float value)
    {
        vol = value;
    }
}
