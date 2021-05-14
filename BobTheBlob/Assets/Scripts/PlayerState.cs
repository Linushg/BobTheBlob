using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
  // Bob the blob
    public int ingredientPoints = 2;
    public int initialIngredientPoints = 0;

    public int amountOfIngredients = 0;

    public GameObject respawnPosition;
    [SerializeField] public GameObject startPosition;
    [SerializeField] public bool useStartPosition;
  

    // Start is called before the first frame update
    void Start()
    {
        ingredientPoints = initial¥IngredientPoints;
        if (useStartPosition == true){
            gameObject.transform.position = startPosition.transform.position;
        }
        respawnPosition = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoHarm(int doHarmByThisMuch) {
        healthPoints -= doHarmByThisMuch;
        if (healthPoints <= 0) {
            Respawn();
        }
    }

    public void Respawn() {
        healthPoints = initialHealthPoints;
        gameObject.transform.position = respawnPosition.transform.position;
    }

    public void CoinPickup() {
        coinAmount++;
    }

    public void ChangeRespawnPosition(GameObject newRespawnPosition) {
        respawnPosition = newRespawnPosition;
    }

}