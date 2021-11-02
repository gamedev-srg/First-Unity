using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    //Script to enable camera to move using WASD relative to view position
    float speedH = 2.0f; //speed of mouse movment Horizontally
    float speedV = 2.0f;//speed of mouse movment Vertically
    float limitSpeed = 5f;// Used to limit the speed the camera moves
    float horizontal = 0.0f;//used to hold current mouse positon
    float vertical = 0.0f;

    Vector3 startingPos;
    
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame

    void Update()
    {
        
        horizontal += speedH * Input.GetAxis("Mouse X");
        //using - here so the camera wont be inversed
        vertical += -(speedV * Input.GetAxis("Mouse Y"));
        //updates camera view using current X,Y positions stored above.
        transform.eulerAngles = new Vector3(vertical, horizontal, 0f);
        //If pressed W or S, move the camera on the plane (as to limit Y axis) forwards (or backwards), towards the camera view.
        if (Input.GetKey(KeyCode.W))
        {
            transform.position +=  Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up)/limitSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up) /limitSpeed ;
        }
        //Moves left or right using A and D keys.
        transform.Translate(Input.GetAxis("Horizontal")/limitSpeed, 0, 0);
    }
}
