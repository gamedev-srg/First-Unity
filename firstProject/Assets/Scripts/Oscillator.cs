using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
   //This vector will set the direction of movement, intialzied to simple values to show it can move on several axis, but can be changed.
    [SerializeField] Vector3 movmentDirection = new Vector3(1f, 0.5f, 0f);
    float movementFactor; //This will represent the speed of change.
    [SerializeField] float period = 4f; //needed to set sinus wave cycles we will call each time, adjustable.
    [SerializeField] float frequency = 2f; //Sin wave frequency, this will also change the speed, adjustable.
    Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position; //object's starting positon, to easly refence it.
    }

    // Update is called once per frame
    void Update()
    {
        //Generally, the Sinus function is exactly what we want in terms of behaviour, it osicllates - it alterantes directions, increases and decreases in speed, and runs indefintly.
        if (period <= 0f) { return; }
        float cycles = Time.time / period; //Using cycles as a function of time will allow us to change the values passed to the sinus function as time progresses.
        const float x = Mathf.PI * 2; //The x that will be passed to the sinus function, needed of coruse to be mulitplied by the amount of cycles we want.
        float sin = Mathf.Sin(cycles * x); // the Sinus wave that we use.

        //print(sin);
        movementFactor = sin / frequency; // to be multiplied each time we call to change our current position.
        Vector3 offset = movementFactor * movmentDirection; // what will be added to our current position, here is where MovmentDirection is important. 
                                                            //Note that we can move in more than 1 axis at a time.
        transform.position = startingPos + offset;//actual change in position

    }
}
