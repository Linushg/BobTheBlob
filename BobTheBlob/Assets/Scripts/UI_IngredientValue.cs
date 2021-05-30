using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_IngredientValue : MonoBehaviour
{    
    private Text textComponent; // För att få kontakt med textkomponenten
    private PlayerState playerState; // För att få kontakt med PlayerState

    void Start()
    {
        playerState = GameObject.Find("playerblob").GetComponent<PlayerState>(); // Hämtar info om Player 
        textComponent = gameObject.GetComponent<Text>(); // Hämtar textkomponenten
    }

    void Update()
    {
       textComponent.text = playerState.ingredientAmount + "" ; // textkomponenten skriver ut vilket genom en sträng vilket värde som finns kvar
    }
}
