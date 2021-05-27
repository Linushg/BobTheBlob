using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthPoints : MonoBehaviour
{
    public PlayerState playerState;
    int maxPlayerHealthPoints;
     private Slider slider;

    void Start()
    {
        maxPlayerHealthPoints = playerState.initialHealthPoints;
        slider = gameObject.GetComponent<Slider>();
        slider.wholeNumbers = true;
        slider.maxValue = maxPlayerHealthPoints;

    }

    void Update()
    {
        slider.value = playerState.healthPoints;
    }
}
