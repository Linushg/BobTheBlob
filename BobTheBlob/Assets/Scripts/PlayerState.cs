using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    public int healthPoints = 2; // Värdet av HP
    public int initialHealthPoints = 3; // Så många HP Bob börjar med
    public int ingredientAmount = 0; // Urspringliga värdet av Ingrediensen

    public GameObject respawnPosition; // initierad plats för Respawn
    public GameObject startPosition; // initierad plats för Start-positionen
    [SerializeField] public bool useStartPosition; //För att kunna ändra utanför scriptet i inspektorn för använda startpositionen
    [SerializeField] int gameover; //För att kunna ändra i inspektorn för ändra GameOver
  
    void Start()
    {
        healthPoints = initialHealthPoints; // Börjar spelet med antalet HP man har
        startPosition = GameObject.Find("start"); //För start 
        if (useStartPosition == true){
            gameObject.transform.position = startPosition.transform.position;
            
        }
        respawnPosition = startPosition; // Respawnpositionen blir startpositionen
    }

    public void DoHarm(int doHarmByThisMuch) { // För att Player ska ta skada
        healthPoints -= doHarmByThisMuch;
        if (healthPoints <= 0) // När Player inte har HP kvar ska Bob dö
        {
            SceneManager.LoadScene(gameover); // Då ska en GameOver Scen visas
        }
        else
        {
            gameObject.transform.position = startPosition.transform.position; // Om det inte är 0 så ska Player börja på startpositionen
        }

    }

    public void Respawn() // För att respawna
    {
        healthPoints = initialHealthPoints; // Player börjar med de initierard HP
    }

    public void IngredientPickup() // Pickup för ingredienser, då kommer det ökas och visas via UI
    {
        ingredientAmount++; // Det ökas
    }

    public void ChangeRespawnPosition(GameObject newRespawnPosition) { // Är till för att byta respawn position
        respawnPosition = newRespawnPosition; // Initierar en ny position
    }

}