using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeltBar : MonoBehaviour
{

    int max_helth=100;
    public Slider slider;
    public Gradient gradinte;
    public Image fill;

    public void SetMax_helth(int maxHelth) 
    {
        max_helth = maxHelth;
        slider.maxValue = maxHelth;
        slider.value = maxHelth;
        fill.color = gradinte.Evaluate(1f);

    }
    public void SetHelt(int Helth) 
    {
        float porcentaje = slider.value / max_helth;
        slider.value = Helth;
        fill.color = gradinte.Evaluate(slider.normalizedValue);
    }
   
}
