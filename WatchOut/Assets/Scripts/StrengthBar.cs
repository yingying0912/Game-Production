using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrengthBar : MonoBehaviour
{
    public Slider slider;

    public void SetStrength(int combo)
    {
        slider.value = combo;
    }
}
