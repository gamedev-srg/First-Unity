using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movmentDirection = new Vector3(0f, 0f, 0f);
    float movementFactor;
    [SerializeField] float period = 4f;
    [SerializeField] float frequency = 1f;
    Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= 0f) { return; }
        float cycles = Time.time / period;
        const float t = Mathf.PI * 2;
        float sin = Mathf.Sin(cycles * t);

        //print(sin);
        movementFactor = sin / frequency + 1f;
        Vector3 offset = movementFactor * movmentDirection;
        transform.position = startingPos + offset;

    }
}
