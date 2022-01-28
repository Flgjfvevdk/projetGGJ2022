using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Slider_Float : MonoBehaviour
{
    public Slider slider;
    public bool mustStopAnim;
    public Animator anim;
    public void init(float maxValue)
    {
        slider.maxValue = maxValue;
    }

    public void setValue(float val)
    {
        slider.value = val;
        if (anim != null && mustStopAnim)
        {
            if(slider.value < slider.maxValue)
            {
                anim.speed = 0.0f;
            } else
            {
                anim.speed = 1.0f;
            }
        }
    }

    
}
