using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Text text;

    private Slider slider;

    public static float gameSessionTime = 5;

    private void Start()
    {
        slider = this.GetComponent<Slider>();
        slider.minValue = 60;
        slider.maxValue = 180;
    }

    public void TextUpdate()
    {
        text.text = "Game session time: " + slider.value;
    }

    public void UpdateGameSessionTime()
    {
        gameSessionTime = slider.value;
    }
}