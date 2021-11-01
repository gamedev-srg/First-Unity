    using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotator : MonoBehaviour
{   //this will be what is passed to the Sinus and CoSinus functions, as a function of time and speed. (To make sure we call it the apropriate amount of times per second);
    float timeC = 0f;
    [SerializeField]
    float speed; //actual speed of rotation, which along with timeC will influence the wave frequency of the Trigo functions.
    [SerializeField]
    float height = 1; //how high (y axis) we want the object to rotate
    float width = 1; // how wide (x axis) we want the object to rotate
    [SerializeField]
    float depth = 0; //how deep(z) we want the object to rotate, will set it to 0 to make it seem like a 2D rotation.
    Vector3 startingPos; //starting position, for easy referencing.



    void Start()
    {
       startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeC += Time.deltaTime * speed; //as discussed above
        float x = Mathf.Cos(timeC) * width; //this will influence the x value of the object
        float y = Mathf.Sin(timeC) * height; //this will influence the y value of the object
        
        transform.position = new Vector3(x, y, depth) + startingPos;//apply change
    }
}   
