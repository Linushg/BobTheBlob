using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthPoints : MonoBehaviour
{
    public PlayerState playerState; // HP kopplas för att kunna ändra det som är initierats i Playerstate eftersom de hör ihop
    int maxPlayerHealthPoints; // int för max antal HP 
     private Slider slider; // Initierar Slidern alltså den so visar en rödsträcka med BobDead spriten

    void Start()
    {
        maxPlayerHealthPoints = playerState.initialHealthPoints; // Börjar med att ha max antal för att få mindre när Player förlorar genom att collidera med spöket 
        slider = gameObject.GetComponent<Slider>(); // För att Slidern ska hittas hämtar man komponenten Slider
        slider.wholeNumbers = true; // För att det bara ska presenteras heltal
        slider.maxValue = maxPlayerHealthPoints;

    }

    void Update()
    {
        slider.value = playerState.healthPoints;  // Slidern speglar vad Player ha för HP
    }
}
