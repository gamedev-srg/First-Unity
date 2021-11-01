using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUnhide : MonoBehaviour
{
    bool isHidden = false;
    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.tag != "ground") {
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
    // Start is called before the first frame update
    void Start()
    {
        cubeHidden = false;
    }
    
    // Update is called once per frame
    void Update()
    {
       
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

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    //Our custom method. 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }
    }
    
   }
