using UnityEngine.UI;
using UnityEngine;

public class OxygenLevel : MonoBehaviour
{

    // Slide ref
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void setOxygen(float Oxygen)
    {
        slider.maxValue = Oxygen;
        slider.value = Oxygen;

       


    }

    public void currentLevel(float oxygen)
    {
        slider.value = oxygen;
       
    }
}
