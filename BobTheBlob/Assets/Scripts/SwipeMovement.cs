using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SwipeMovement : MonoBehaviour
{
    //public playerblob playerblob;
    private Vector2 startPos;
    public int pixelDistToDectect = 50;
    private bool fingerDown;

    void Update ()
    {
        
        
        // Check if Platform is Android
        if (Application.platform == RuntimePlatform.Android) 
        { 
        
            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape)) {
            
                // Quit to main menu
                SceneManager.LoadScene(0);
            }
            ///////////////
            //Touch input//
            ///////////////

            if(fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                startPos = Input.touches[0].position;
                fingerDown = true;
            }
            //Is the screen being touched?
            if(fingerDown)
            {
                //Is the screen being swiped up?
                if(Input.touches[0].position.y >= startPos.y + pixelDistToDectect)
                {
                    fingerDown = false;
                    Debug.Log("Swipe up");
                }

                //Is the screen being swiped left?

                else if(Input.touches[0].position.x <= startPos.x - pixelDistToDectect)
                {
                    fingerDown = false;
                    Debug.Log("Swipe left");
                }

                //Is the screen being swiped right?

                else if(Input.touches[0].position.x >= startPos.x + pixelDistToDectect)
                {
                    fingerDown = false;
                    Debug.Log("Swipe right");
                }

                //Is the screen being swiped down?
                else if(Input.touches[0].position.y <= startPos.y - pixelDistToDectect)
                {
                    fingerDown = false;
                    Debug.Log("Swipe down");
                }
            }

            if(fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
            {
                fingerDown = false;
            }
        }
        
        ////////////////////////////////
        //TESTING FOR PC (MOUSE INPUT)//
        ////////////////////////////////

        if(fingerDown == false && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            fingerDown = true;
        }

        if(fingerDown)
        {
            //Is the screen being swiped up?
            if(Input.mousePosition.y >= startPos.y + pixelDistToDectect)
            {
                fingerDown = false;
                Debug.Log("Mouse up");
            }

            //Is the screen being swiped left?

            else if(Input.mousePosition.x <= startPos.x - pixelDistToDectect)
            {
                fingerDown = false;
                Debug.Log("Mouse left");
            }

            //Is the screen being swiped right?

            else if(Input.mousePosition.x >= startPos.x + pixelDistToDectect)
            {
                fingerDown = false;
                Debug.Log("Mouse right");
            }
            
            //Is the screen being swiped down?
            else if(Input.mousePosition.y <= startPos.y - pixelDistToDectect)
            {
                fingerDown = false;
                Debug.Log("Mouse down");
            }    
            
        }
        if (fingerDown && Input.GetMouseButtonUp(0))
        {
            fingerDown = false;
        }
    }
}
