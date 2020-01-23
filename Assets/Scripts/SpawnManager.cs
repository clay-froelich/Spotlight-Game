using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject monster;
    public GameObject[] boosts;
    public PlayerController playerController;
    public bool gameOver;
    public float xBound = 24;
    public float zBound = 9.5f;

    void SpawnHealthUp() {
        Instantiate(boosts[0], new Vector3(Random.Range(-xBound, xBound), 0.5f, Random.Range(-zBound,zBound)), boosts[0].transform.rotation);
        float waitTime = Random.Range(30f, 90f);
        if (!gameOver) {
            Invoke("SpawnHealthUp", waitTime);
        }
    }

    void SpawnWeaponUp() {
        Instantiate(boosts[1], new Vector3(Random.Range(-xBound, xBound), 0.5f, Random.Range(-zBound,zBound)), boosts[0].transform.rotation);
        float waitTime = Random.Range(30f, 90f);
        if (!gameOver) {
            Invoke("SpawnHealthUp", waitTime);
        }
    }
    
    void SpawnMonster() {
        Vector3 randomLocation = new Vector3(Random.Range(-xBound, xBound), 0.5f, Random.Range(-zBound, zBound));
        Instantiate(monster, randomLocation, monster.transform.rotation);
        float randomWait = Random.Range(2f, 4f);
        if (!gameOver) {
            Invoke("SpawnMonster", randomWait);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Invoke("SpawnMonster", 3f);
        Invoke("SpawnHealthUp", 60f);
        Invoke("SpawnWeaponUp", 90f);
    }

    void Update() {
        gameOver = playerController.gameOver;
    }

    
    
}
