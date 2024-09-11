using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stanamabar : MonoBehaviour
{

    public Slider slider;

    public void setMax(float sprint)
    {
        slider.maxValue = sprint;
        slider.value = sprint;
    }

    public void setstanama(float sprint)
    {
        slider.value = sprint;
    }
}
