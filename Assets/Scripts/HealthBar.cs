using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Slide ref
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void setMaxHp(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);


    }


    public void setHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
