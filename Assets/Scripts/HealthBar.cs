using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _slider;


    public void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void SetHealth(float currentHealth)
    {
        _slider.value = currentHealth/100f;
    }
}
