using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    public float speed;
    public bool canMove = false;
    public Rigidbody2D rb;
    private Vector2 startPos;
    public int pixelDistToDectect = 50;
    private bool fingerDown;
    SpriteRenderer spriteRenderer;
    bool isFacingRight = true;



    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            /*Vector2 tempPosition = transform.position;
            tempPosition.x = Mathf.Round(tempPosition.x);
            tempPosition.y = Mathf.Round(tempPosition.y);
            transform.position = tempPosition;*/
            
            ////////////////////////
            /////KEYBOARD INPUT/////
            ////////////////////////

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = new Vector2(0, 1 * speed * Time.deltaTime); //moves bob  thru adding a force to his ridgid body
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                rb.velocity = new Vector2(0, -1 * speed * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                rb.velocity = new Vector2(-1 * speed * Time.deltaTime, 0);
                isFacingRight = false;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                rb.velocity = new Vector2(1 * speed * Time.deltaTime, 0);
                isFacingRight = true;
            }

            // Check if Esc/Back (Android) was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                // Quit to main menu
                SceneManager.LoadScene(0);
            }



            /////////////////////
            /////TOUCH INPUT/////
            /////////////////////


            // Check if Platform is Android
            if (Application.platform == RuntimePlatform.Android)
            {


                if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
                {
                    startPos = Input.touches[0].position;
                    fingerDown = true;
                }
                //Is the screen being touched?
                if (fingerDown)
                {
                    //Is the screen being swiped up?
                    if (Input.touches[0].position.y >= startPos.y + pixelDistToDectect)
                    {
                        fingerDown = false;
                        rb.velocity = new Vector2(0, 1 * speed * Time.deltaTime);
                        Debug.Log("Swipe up");
                    }

                    //Is the screen being swiped down?
                    else if (Input.touches[0].position.y <= startPos.y - pixelDistToDectect)
                    {
                        fingerDown = false;
                        rb.velocity = new Vector2(0, -1 * speed * Time.deltaTime);
                        Debug.Log("Swipe down");
                    }

                    //Is the screen being swiped left?

                    else if (Input.touches[0].position.x <= startPos.x - pixelDistToDectect)
                    {
                        fingerDown = false;
                        rb.velocity = new Vector2(-1 * speed * Time.deltaTime, 0);
                        isFacingRight = false;
                        Debug.Log("Swipe left");
                    }

                    //Is the screen being swiped right?

                    else if (Input.touches[0].position.x >= startPos.x + pixelDistToDectect)
                    {
                        fingerDown = false;
                        rb.velocity = new Vector2(1 * speed * Time.deltaTime, 0);
                        isFacingRight = true;
                        Debug.Log("Swipe right");
                    }

                    //If none of the above, assume Screen Tap
                    else
                    {
                        Debug.Log("Screen Tap");
                    }

                    
                }

                if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
                {
                    fingerDown = false;
                }
            }

            ////////////////////////////////
            //TESTING FOR PC (MOUSE INPUT)//
            ////////////////////////////////

            if (fingerDown == false && Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
                fingerDown = true;

            }

            if (fingerDown)
            {
                //Is the screen being swiped up?
                if (Input.mousePosition.y >= startPos.y + pixelDistToDectect)
                {
                    fingerDown = false;
                    rb.velocity = new Vector2(0, 1 * speed * Time.deltaTime);
                    Debug.Log("Mouse up");
                }

                //Is the screen being swiped down?
                else if (Input.mousePosition.y <= startPos.y - pixelDistToDectect)
                {
                    fingerDown = false;
                    rb.velocity = new Vector2(0, -1 * speed * Time.deltaTime);
                    Debug.Log("Mouse down");
                }

                //Is the screen being swiped left?

                else if (Input.mousePosition.x <= startPos.x - pixelDistToDectect)
                {
                    fingerDown = false;
                    rb.velocity = new Vector2(-1 * speed * Time.deltaTime, 0);
                    isFacingRight = false;
                    Debug.Log("Mouse left");
                }

                //Is the screen being swiped right?

                else if (Input.mousePosition.x >= startPos.x + pixelDistToDectect)
                {
                    fingerDown = false;
                    rb.velocity = new Vector2(1 * speed * Time.deltaTime, 0);
                    isFacingRight = true;
                    Debug.Log("Mouse right");
                }

                //If none of the above, assume Mouse Click
                
                else
                {
                    Debug.Log("Mouse click");
                }

            }
            if (fingerDown && Input.GetMouseButtonUp(0))
            {
                fingerDown = false;
            }

        }
        
        if(isFacingRight == true)
        {
            spriteRenderer.flipX = false;
            //isFacingRight = true;
        } else if (isFacingRight == false)
        {
            spriteRenderer.flipX = true;
            //isFacingRight = false;
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Start")
        {
            //Debug.Log("Start");
            canMove = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall"/* && rb.velocity.x == 0 && rb.velocity.y == 0*/)
        {
            canMove = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canMove = false;
    }
}
