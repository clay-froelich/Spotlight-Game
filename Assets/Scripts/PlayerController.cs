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

            // boundary checking
            /*if (transform.position.x > xBounds) {
                transform.position = new Vector3(xBounds, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -xBounds) {
                transform.position = new Vector3(-xBounds, transform.position.y, transform.position.z);
            }

            if (transform.position.z > zBounds) {
                transform.position = new Vector3(transform.position.x, transform.position.y, zBounds);
            }
            else if (transform.position.z < -zBounds) {
                transform.position = new Vector3(transform.position.x, transform.position.y, -zBounds);
            }*/

            // rotate and move forward
            transform.rotation = Quaternion.LookRotation(lookDirection);
            Rigidbody playerRigidBody = gameObject.GetComponent<Rigidbody>();
            playerRigidBody.AddForce(lookDirection * Time.deltaTime * speed * 5, ForceMode.VelocityChange);
            //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        // player attack
        if (Input.GetKeyDown(KeyCode.Space)) {
            // projectile for now
            Instantiate(projectiles[projectileLevel], transform.position, transform.rotation);
        }
    }
}
