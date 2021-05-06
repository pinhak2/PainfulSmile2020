using UnityEngine;
using UnityEngine.UI;

public class HealthbarBehaviour : MonoBehaviour
{
    public Slider slider;
    public Color lowLifeColor;
    public Color highHealthColor;
    public Vector3 offsetFromTarget;

    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive((health < maxHealth) && (health > 0));
        slider.value = health;
        slider.maxValue = maxHealth;
        ChangeHealthbarColor();
    }

    private void Update()
    {
        SetHealthbarPosition();
    }

    private void ChangeHealthbarColor()
    {
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(lowLifeColor, highHealthColor, slider.normalizedValue);
    }

    private void SetHealthbarPosition()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offsetFromTarget);
    }
}