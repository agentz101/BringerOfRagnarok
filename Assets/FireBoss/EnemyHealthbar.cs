using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void UpdateHealthbar(float currentValue, float maxValue)
    {
        slider.value = currentValue;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
