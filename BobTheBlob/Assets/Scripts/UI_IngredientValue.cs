using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_IngredientValue : MonoBehaviour
{    
    private Text textComponent;
    private PlayerState playerState;

    void Start()
    {
        playerState = GameObject.Find("playerblob").GetComponent<PlayerState>();
        textComponent = gameObject.GetComponent<Text>();
    }

    void Update()
    {
       textComponent.text = playerState.ingredientAmount + "" ; 
    }
}
