using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject monster;
    public GameObject[] boosts;

    void SpawnHealthUp() {
        /*int corner = Random.Range(1, 5);
        if (corner == 1) {
            Instantiate(boosts[0], new Vector3(25, 0, 10), boosts[0].transform.rotation);
        }
        else if (corner == 2) {
            Instantiate(boosts[0], new Vector3(25, 0, -10), boosts[0].transform.rotation);
        }
        else if (corner == 3) {
            Instantiate(boosts[0], new Vector3(-25, 0, -10), boosts[0].transform.rotation);
        }
        else{
            Instantiate(boosts[0], new Vector3(-25, 0, 10), boosts[0].transform.rotation);
        }*/
        Instantiate(boosts[0], new Vector3(Random.Range(-25f, 25f), 0, Random.Range(-10f,10f)), boosts[0].transform.rotation);
        float waitTime = Random.Range(30f, 90f);
        Invoke("SpawnHealthUp", waitTime);
    }

    void SpawnWeaponUp() {
        /*int corner = Random.Range(1, 5);
        if (corner == 1) {
            Instantiate(boosts[0], new Vector3(25, 0, 10), boosts[0].transform.rotation);
        }
        else if (corner == 2) {
            Instantiate(boosts[0], new Vector3(25, 0, -10), boosts[0].transform.rotation);
        }
        else if (corner == 3) {
            Instantiate(boosts[0], new Vector3(-25, 0, -10), boosts[0].transform.rotation);
        }
        else{
            Instantiate(boosts[0], new Vector3(-25, 0, 10), boosts[0].transform.rotation);
        }*/
        Instantiate(boosts[1], new Vector3(Random.Range(-25f, 25f), 0, Random.Range(-10f,10f)), boosts[0].transform.rotation);
        float waitTime = Random.Range(30f, 90f);
        Invoke("SpawnHealthUp", waitTime);
    }
    
    void SpawnMonster() {
        Vector3 randomLocation = new Vector3(Random.Range(-25, 25), 0.5f, Random.Range(-10, 10));
        Instantiate(monster, randomLocation, monster.transform.rotation);
        float randomWait = Random.Range(2f, 4f);
        Invoke("SpawnMonster", randomWait);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnMonster", 3f);
        Invoke("SpawnHealthUp", 60f);
        Invoke("SpawnWeaponUp", 90f);
    }

    
    
}
