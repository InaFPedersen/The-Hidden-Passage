using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // setting max exp on bar
    public void SetStartXP(int experience)
    {
        slider.minValue = experience;
        slider.value = experience;

        fill.color = gradient.Evaluate(0f);
    }

    // changing displayed Exp on bar + colour changes when gaining exp
    public void SetXP(int experience)
    {
        slider.value = experience;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
