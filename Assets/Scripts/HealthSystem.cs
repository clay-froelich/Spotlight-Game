using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    
    IEnumerator WaitTime(float time) {
        yield return new WaitForSeconds(time);
    }
    void Update()
    {
        if (currentHealth <= 0) {
            if (gameObject.CompareTag("Player")) {
                playerController.gameOver = true;

            }
            else if (gameObject.CompareTag("Monster")) {
                Animator monsterAnim = gameObject.GetComponent<Animator>();
                monsterAnim.SetBool("isDead", true);
                WaitTime(1);
            }
            Destroy(gameObject);
        }

        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
    }
}
