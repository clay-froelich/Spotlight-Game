using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0) {
            if (gameObject.CompareTag("Player")) {
                gameManager.gameOver = true;
                gameManager.GameOver();
            }
            else if (gameObject.name == "Boximon Fiery(Clone)") {
                gameManager.redKills++;
            }
            else if (gameObject.name == "Boximon Cyclopes(Clone)") {
                gameManager.blueKills++;
            }
            Destroy(gameObject);
        }

        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
    }
}
