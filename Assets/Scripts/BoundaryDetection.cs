using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoundaryDetection : MonoBehaviour
{
    public float xBoundary = 45f;
    public float zBoundary = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(gameObject.transform.position.x) > xBoundary) {
            Destroy(gameObject);
        }
        else if (Math.Abs(gameObject.transform.position.z) > zBoundary) {
            Destroy(gameObject);
        }
    }
}
