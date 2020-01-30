using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAroundMouse : MonoBehaviour
{
    public float mouseX;
    public float yFromCamera = 18f;
    public float mouseZ;
    public float decreaseTime = 5f;
    public Light light;

    public GameManager gameManager;
    
    void DecreaseLight() {
        if (light.range > 17 && !gameManager.gameOver && gameManager.gameStart) {
            light.range -= 0.1f;
        }
        Invoke("DecreaseLight", decreaseTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Invoke("DecreaseLight", decreaseTime);
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.mousePosition.x;
        mouseZ = Input.mousePosition.y;
        transform.position = (Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseZ, yFromCamera)) + new Vector3(0, yFromCamera, 0));
    }
}
