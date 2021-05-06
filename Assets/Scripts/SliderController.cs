using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Text text;

    Slider slider;
    
    void Start()
    {
        slider = this.GetComponent<Slider>();
        slider.minValue = 60;
        slider.maxValue = 180;
    }

    // Update is called once per frame
    public void TextUpdate()
    {
        text.text = "Game session time: " + slider.value;
    }
}
