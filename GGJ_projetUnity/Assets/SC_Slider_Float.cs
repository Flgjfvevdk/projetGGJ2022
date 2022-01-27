using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Slider_Float : MonoBehaviour
{
    public Slider slider;
    public void init(float maxValue)
    {
        slider.maxValue = maxValue;
    }

    public void setValue(float val)
    {
        slider.value = val;
    }
}
