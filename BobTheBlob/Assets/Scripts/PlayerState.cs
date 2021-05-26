using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
  // Bob the blob
    public int healthPoints = 2;
    public int initialHealthPoints = 3;
    public int ingredientAmount = 0;

    /*public GameObject respawnPosition;
    [SerializeField] public GameObject startPosition;
    [SerializeField] public bool useStartPosition;
  */

    // Start is called before the first frame update
    void Start()
    {
        healthPoints = initialHealthPoints;

        /* if (useStartPosition == true){
            gameObject.transform.position = startPosition.transform.position;
        }
        respawnPosition = startPosition; */
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
        if (healthPoints <= 0) {
            Respawn();
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

    /*public void ChangeRespawnPosition(GameObject newRespawnPosition) {
        respawnPosition = newRespawnPosition;
    }*/

}