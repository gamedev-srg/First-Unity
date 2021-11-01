    using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotator : MonoBehaviour
{
    float timeC = 0f;
    [SerializeField]
    float speed;
    [SerializeField]
    float height;
    [SerializeField]
    float width;
    
    Vector3 startingPos;



    void Start()
    {
       startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeC += Time.deltaTime * speed;
        float x = Mathf.Cos(timeC) * width; 
        float y = Mathf.Sin(timeC) * height;
        float z = 10f;  
        transform.position = new Vector3(x, y, z) + startingPos;
    }
}   
