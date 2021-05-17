using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;
    private float movementDirection = 1f;

    Rigidbody2D rigidBody2D;
    /*private Animator animator;*/

    public GameObject groundCheck;

    bool isGrounded;

    private bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        /*animator = gameObject.GetComponent<Animator>();*/
    }

    private void Update()
    {
        /*animator.SetBool("isAlive", isAlive);
        animator.SetBool("isGrounded", isGrounded);*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGrounded == true && isAlive == true)
        {
            Vector3 newPosition = gameObject.transform.position;
            newPosition.x += speed * Time.fixedDeltaTime * movementDirection;
            rigidBody2D.MovePosition(newPosition);
        }

        if (isAlive == true)
        {

            if (isGrounded == false)
            {
                /*ChangeDirection(); */
            }
        }
    }

    private void CheckForGround()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        movementDirection = -movementDirection;
        Vector3 newScale = gameObject.transform.localScale;
        newScale.x = movementDirection;
        gameObject.transform.localScale = newScale;
    }

    /*public void KillMe()
    {
        isAlive = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Vector2 killForce = new Vector2(movementDirection, 4f);
        rigidBody2D.AddForce(killForce, ForceMode2D.Impulse);
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, -gameObject.transform.localScale.y);
    }*/
            }

