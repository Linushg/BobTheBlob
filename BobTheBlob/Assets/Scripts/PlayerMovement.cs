using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spritrenderer;
    private Animator animator;

    public GameObject groundCheck;
    private bool isGrounded;

    public float movementSpeed = 2f;
    private float defaultMovementSpeed;

    private bool isVertical;
    private bool isHorizontal;
    private float moveDirection = 0f;
    public float jumpForce = 10f;

    private bool isFacingLeft = false;

    private Vector3 velocity;
    public float smoothTime = 0.2f;

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
    private Vector2 startPos;
    public int pixelDistToDectect = 50;
    private bool mouseButtonDown;
    [SerializeField] private LayerMask whatIsGround;

    public void Start()
    {
        defaultMovementSpeed = movementSpeed;
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        spritrenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
    }

    // Update is called once per frame
    void Update()
    {

        /////KEYBOARD INPUT/////
        
        
        if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.UpArrow) == true)
        {
            moveDirection = Input.GetAxis("Vertical");
            isVertical = true;
            isHorizontal = false; //Locks the player so it cant move horizontally
        }

        if (Input.GetKey(KeyCode.S) == true || Input.GetKey(KeyCode.DownArrow) == true)
        {
            moveDirection = Input.GetAxis("Vertical");
            isVertical = true;
            isHorizontal = false;
        }

        if (Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.D) == true || Input.GetKey(KeyCode.LeftArrow) == true || Input.GetKey(KeyCode.RightArrow) == true)
        {
            moveDirection = Input.GetAxis("Horizontal");
            isVertical = false; //Locks the player so it cant move  verticlly
            isHorizontal = true;
        }

	    // Check if Esc/Back (Android) was pressed this frame
        if (Input.GetKeyDown(KeyCode.Escape)) {
            
            // Quit to main menu
            SceneManager.LoadScene(0);
        }
        

        /////TOUCH INPUT/////
        
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            Debug.Log("Bob Right Swipe");
                            moveDirection = Input.GetAxis("Horizontal");
                            isVertical = false;
                            isHorizontal = true;
                        }
                        else
                        {   //Left swipe
                            Debug.Log("Bob Left Swipe");
                            moveDirection = Input.GetAxis("Horizontal");
                            isVertical = false;
                            isHorizontal = true;
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            Debug.Log("Bob Up Swipe");
                            moveDirection = Input.GetAxis("Vertical");
                            isVertical = true;
                            isHorizontal = false;
                        }
                        else
                        {   //Down swipe
                            Debug.Log("Bob Down Swipe");
                            moveDirection = Input.GetAxis("Vertical");
                            isVertical = true;
                            isHorizontal = false;
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                }
            }

        }

        /////MOUSE INPUT/////

        if(mouseButtonDown == false && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            mouseButtonDown = true;
        }

        if(mouseButtonDown)
        {
            //Is the screen being swiped up?
            if(Input.mousePosition.y >= startPos.y + pixelDistToDectect)
            {
                mouseButtonDown = false;
                moveDirection = Input.GetAxis("Vertical");
                isVertical = true;
                isHorizontal = false;
                Debug.Log("Mouse up");
            }

            //Is the screen being swiped down?
            else if(Input.mousePosition.y <= startPos.y - pixelDistToDectect)
            {
                mouseButtonDown = false;
                moveDirection = Input.GetAxis("Vertical");
                isVertical = true;
                isHorizontal = false;
                Debug.Log("Mouse down");
            }    

            //Is the screen being swiped left?

            else if(Input.mousePosition.x <= startPos.x - pixelDistToDectect)
            {
                mouseButtonDown = false;
                moveDirection = Input.GetAxis("Horizontal");
                isVertical = false;
                isHorizontal = true;
                Debug.Log("Mouse left");
            }

            //Is the screen being swiped right?

            else if(Input.mousePosition.x >= startPos.x + pixelDistToDectect)
            {
                mouseButtonDown = false;
                moveDirection = Input.GetAxis("Horizontal");
                isVertical = false;
                isHorizontal = true;
                Debug.Log("Mouse right");
            }
            
            
            
        }
        if (mouseButtonDown && Input.GetMouseButtonUp(0))
        {
            mouseButtonDown = false;
        }

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

        if (isVertical == true)
        {
            calculatedMovement.y = movementSpeed * 100f * moveDirection;
        }
        if (isHorizontal == true)
        {
            calculatedMovement.x = movementSpeed * 100f * moveDirection;
        }

        Move(calculatedMovement);
        isHorizontal = false;
        isVertical = false;
    }

    private void Move(Vector2 moveDirection)
    {
        rigidBody2D.velocity = Vector3.SmoothDamp(rigidBody2D.velocity, moveDirection, ref velocity, smoothTime);
    }

    private void FlipSpriteDirection()
    {
        spritrenderer.flipX = !isFacingLeft;
        isFacingLeft = !isFacingLeft;
    }
}
