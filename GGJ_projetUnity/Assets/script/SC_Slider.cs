using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SC_Slider : MonoBehaviour
{
    public Slider slider;
    private void Start()
    {
        // slider = GetComponent<Slider>();
    }
    public void init(int maxValue)
    {
        slider.maxValue = maxValue;
        Debug.Log("init");
    }

    public void setValue(int val)
    {
        slider.value = val;
        Debug.Log("setvalue");
    }
}
