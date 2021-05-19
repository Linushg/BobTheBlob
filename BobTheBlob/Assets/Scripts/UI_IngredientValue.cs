using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_IngredientValue : MonoBehaviour
{    
    private Text textComponent;
    private PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        playerState = GameObject.Find("playerblob").GetComponent<PlayerState>();
        textComponent = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       textComponent.text = playerState.ingredientAmount + "" ; 
    }
}
