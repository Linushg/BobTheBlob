using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spritrenderer;
    private Animator animator;

    public GameObject groundCheck;
    private bool isGrounded;

    public float movementSpeed = 2f;
    private float defaultMovementSpeed;

    private bool isMoving;
    private bool isVertical;
    private bool isHorizontal;
    private float moveDirection = 0f;
    private bool isJumpPressed = false;
    public float jumpForce = 10f;

    private bool isFacingLeft = false;

    private Vector3 velocity;
    public float smoothTime = 0.2f;

    [SerializeField] private LayerMask whatIsGround;

    public void Start()
    {
        defaultMovementSpeed = movementSpeed;
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        spritrenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //moveDirection = Input.GetAxis("Horizontal");
        //moveDirection = Input.GetAxis("Vertical");
        if (Mathf.Abs(moveDirection) > 0.05)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (Input.GetKey(KeyCode.W) == true)
        {
            moveDirection = Input.GetAxis("Vertical");
            isVertical = true;
            isHorizontal = false;
        }

        if (Input.GetKey(KeyCode.S) == true)
        {
            moveDirection = Input.GetAxis("Vertical");
            isVertical = true;
            isHorizontal = false;
        }

        if (Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.D) == true)
        {
            moveDirection = Input.GetAxis("Horizontal");
            isVertical = false;
            isHorizontal = true;
        }

        //animator.SetBool("IsGrounded", isGrounded);
        //animator.SetFloat("Speed", Mathf.Abs(moveDirection));
    }

    private void FixedUpdate()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f, whatIsGround);


        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
            }
        }

        Vector3 calculatedMovement = Vector3.zero;

        if (isGrounded == false)
        {
            
        }



        //calculatedMovement.x = movementSpeed * 100f * moveDirection * Time.fixedDeltaTime;
        if (isVertical == true) { 
            calculatedMovement.y = movementSpeed * 100f * moveDirection * Time.fixedDeltaTime; 
        }
        if (isHorizontal == true)
        {
            calculatedMovement.x = movementSpeed * 100f * moveDirection * Time.fixedDeltaTime;
        }

        Move(calculatedMovement, isJumpPressed);
        isJumpPressed = false;
        isHorizontal = false;
        isVertical = false;
    }

    private void Move(Vector3 moveDirection, bool isJumpPressed)
    {
        rigidBody2D.velocity = Vector3.SmoothDamp(rigidBody2D.velocity, moveDirection, ref velocity, smoothTime);

       /* if (isJumpPressed == true && isGrounded == true)
        {
            rigidBody2D.AddForce(new Vector2(0f, jumpForce * 100f));
        }

        if (moveDirection.x > 0f && isFacingLeft == true)
        {
            FlipSpriteDirection();
        }

        else if (moveDirection.x < 0f && isFacingLeft == false)
        {
            FlipSpriteDirection();
        }*/

    }

    private void FlipSpriteDirection()
    {
        spritrenderer.flipX = !isFacingLeft;
        isFacingLeft = !isFacingLeft;
    }
}
