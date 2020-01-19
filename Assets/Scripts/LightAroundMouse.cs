using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAroundMouse : MonoBehaviour
{
    public float mouseX;
    public float yFromCamera = 18f;
    public float mouseZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.mousePosition.x;
        mouseZ = Input.mousePosition.y;
        Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseZ, yFromCamera)));
        transform.position = (Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseZ, yFromCamera)) + new Vector3(0, yFromCamera, 0));

    }
}
