using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCheck : MonoBehaviour
{
    [SerializeField] public int ingredientGoal = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            //Debug.Log("Hit");
            if (collision.GetComponent<PlayerState>().ingredientAmount >= ingredientGoal)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            //Debug.Log("Hit");
            if (collision.GetComponent<PlayerState>().ingredientAmount >= ingredientGoal)
            {
                Destroy(gameObject);
            }
        }
    }
}
