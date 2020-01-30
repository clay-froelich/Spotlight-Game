using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] monsters;
    public GameObject[] boosts;
    public GameManager gameManager;
    public float xBound = 24;
    public float zBound = 9.5f;

    void SpawnHealthUp() {
        Instantiate(boosts[0], new Vector3(Random.Range(-xBound, xBound), 0f, Random.Range(-zBound,zBound)), boosts[0].transform.rotation);
        float waitTime = Random.Range(30f, 90f);
        if (!gameManager.gameOver) {
            Invoke("SpawnHealthUp", waitTime);
        }
    }

    void SpawnWeaponUp() {
        Instantiate(boosts[1], new Vector3(Random.Range(-xBound, xBound), 0f, Random.Range(-zBound,zBound)), boosts[0].transform.rotation);
        float waitTime = Random.Range(30f, 90f);
        if (!gameManager.gameOver) {
            Invoke("SpawnWeaponUp", waitTime);
        }
    }
    
    void SpawnMonster() {
        int randIndex = Random.Range(0, monsters.Length);
        Vector3 randomLocation = new Vector3(Random.Range(-xBound, xBound), 0f, Random.Range(-zBound, zBound));
        Instantiate(monsters[randIndex], randomLocation, monsters[randIndex].transform.rotation);
        float randomWait = Random.Range(2f, 4f);
        if (!gameManager.gameOver) {
            Invoke("SpawnMonster", randomWait);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update() {
    }
    
    public void StartSpawns() {
        Invoke("SpawnMonster", 3f);
        Invoke("SpawnHealthUp", 60f);
        Invoke("SpawnWeaponUp", 90f);
    }

    
    
}
