using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulser : MonoBehaviour
{
    [SerializeField] float scaleRate = 0.01f;
    [SerializeField] float maxScale = 2.0f;
    [SerializeField] float minScale = 0.2f;
    Vector3 startPos;
    Vector3 startingScale;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startingScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < minScale)
        {
            scaleRate = Mathf.Abs(scaleRate);
        }
        else if(transform.localScale.x > maxScale)
        {
            scaleRate = -Mathf.Abs(scaleRate);
        }
        transform.localScale += Vector3.one * scaleRate;
    }
}
