using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImmuneBar : MonoBehaviour
{
    public Slider slider;

    public void SetImmune(int combo)
    {
        slider.value = combo;
    }
}
