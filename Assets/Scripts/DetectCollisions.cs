using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public float elapsedTime = 0f;
    public float timeBeforeHealthDrain = 1.5f;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon" && gameObject.tag == "Monster") {
            // lose health equal to power on weapon
            HealthSystem hs = gameObject.GetComponent<HealthSystem>();
            WeaponSystem ws = other.gameObject.GetComponent<WeaponSystem>();
            hs.currentHealth -= ws.damageOnHit;
            Destroy(other.gameObject);
        }

        else if (gameObject.tag == "Player" && other.tag == "HealthUp") {
            HealthSystem hs = gameObject.GetComponent<HealthSystem>();
            hs.currentHealth += 2;
            Destroy(other.gameObject);
        }

        // have not decided on weapon upgrade yet
        else if (gameObject.tag == "Player" && other.tag == "WeaponUp") {
            gameObject.GetComponent<PlayerController>().projectileLevel++;
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player" && gameObject.tag == "Monster") {
            // player loses health
            HealthSystem playerhs = collisionInfo.collider.gameObject.GetComponent<HealthSystem>();
            playerhs.currentHealth -= 1;

            //player knocked back
            Vector3 moveDirection = new Vector3 (collisionInfo.collider.gameObject.transform.position.x - gameObject.transform.position.x, 
                                                0, collisionInfo.collider.gameObject.transform.position.z - gameObject.transform.position.z).normalized;
            Rigidbody playerRigidBody = collisionInfo.collider.gameObject.GetComponent<Rigidbody>();
            float knockbackForce = gameObject.GetComponent<MonsterController>().knockbackForce;
            playerRigidBody.AddForce(moveDirection * knockbackForce);
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player" && gameObject.tag == "Monster") {
            
            elapsedTime += Time.fixedDeltaTime;

            if (elapsedTime > timeBeforeHealthDrain) {
                HealthSystem playerhs = collisionInfo.collider.gameObject.GetComponent<HealthSystem>();
                playerhs.currentHealth -= 1;
                elapsedTime = 0;
            }
        }
    }
}
