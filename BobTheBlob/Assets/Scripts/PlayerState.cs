using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
  // Bob the blob
    public int healthPoints = 2;
    public int initialHealthPoints = 3;
    public int ingredientAmount = 0;

    public GameObject respawnPosition;
    public GameObject startPosition;
    [SerializeField] public bool useStartPosition;
    [SerializeField] int gameover;
  

    // Start is called before the first frame update
    void Start()
    {
        healthPoints = initialHealthPoints;
        startPosition = GameObject.Find("start");
        if (useStartPosition == true){
            gameObject.transform.position = startPosition.transform.position;
            
        }
        respawnPosition = startPosition; 
    }

    // Update is called once per frame
   /* void Update() //kanske jättekonstigt
    {
        private void onTriggerEnter2D(Collider collision){
            if (collision.CompareTag("Wall")== true){
               Shake(this); //gameobject
            }
        }

    }*/

    public void DoHarm(int doHarmByThisMuch) {
        healthPoints -= doHarmByThisMuch;
        if (healthPoints <= 0) 
        {
            SceneManager.LoadScene(gameover);
        }
        else
        {
            gameObject.transform.position = startPosition.transform.position;
            
        }

    }

    public void Respawn()
    {
        healthPoints = initialHealthPoints;
    }

    public void IngredientPickup()
    {
        ingredientAmount++;
    }

    public void ChangeRespawnPosition(GameObject newRespawnPosition) {
        respawnPosition = newRespawnPosition;
    }

}