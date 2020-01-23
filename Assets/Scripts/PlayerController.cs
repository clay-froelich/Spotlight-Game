using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 15f;
    public float xBounds = 25f;
    public float zBounds = 10f; 
    public GameObject[] projectiles;
    public int projectileLevel;
    private float horizontalInput;
    private float verticalInput;
    public bool gameOver = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // player movement
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
        // rotate direction calculation
        Vector3 lookDirection = new Vector3(horizontalInput, 0, verticalInput);
        
        // only execute when user gives input
        if (horizontalInput != 0 || verticalInput != 0) {

            // rotate and move forward
            transform.rotation = Quaternion.LookRotation(lookDirection);
            Rigidbody playerRigidBody = gameObject.GetComponent<Rigidbody>();
            playerRigidBody.AddForce(lookDirection * Time.deltaTime * speed * 5, ForceMode.VelocityChange);
        }

        // player attack
        if (Input.GetKeyDown(KeyCode.Space)) {
            // projectile for now
            Instantiate(projectiles[projectileLevel], transform.position, transform.rotation);
        }
    }
}
