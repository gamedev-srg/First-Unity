using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUnhide : MonoBehaviour
{

   //This function is called on any game object that is passed to it, regardless if the script was attached to it or not.
    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.tag != "ground") { //Since we don't want the ground to dissappear when we click on it.
            //Simply checks if hidden or not with a boolean flag, and acts accordingly. important to change the flag, otherwise, we will be stuck in a hidden/shown mode.
            if (!isHidden)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                isHidden = true;
                return;
            }
            gameObject.GetComponent<Renderer>().enabled = true;
            isHidden = false;
            return;
        }
    }
    bool cubeHidden;
    bool isHidden;
    // Start is called before the first frame update
    void Start()
    {
        isHidden = false;
        cubeHidden = false;
    }
    
    // Update is called once per frame
    void Update()
    {
       //This causes the cube's renderer to be disabled once space is clicked.
       //note that unlike the CurrentClickedGameObject function, that also disables the renderer, this part only applies to the cube.
       //why? simply because we attach this script to the cube. any other Object we will attach this script to will also be hidden by pressing space.
        if (Input.GetKeyDown("space"))
        {
            if (!cubeHidden)
            {   

                GetComponent<Renderer>().enabled = false;
                cubeHidden = true;
               
            }
            else 
            {
                GetComponent<Renderer>().enabled = true;
                cubeHidden = false;
            }
            
        }

        //checks if LMB was pressed,
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit; //raycast is a way to check where the cursor is pointing at, from the view of the camera.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null) //checks if I clicked on an object
                {
                    //Our custom method. 
                    CurrentClickedGameObject(raycastHit.transform.gameObject); //gets the object that was hit and call the function on it.
                }
            }
        }
    }
    
   }
