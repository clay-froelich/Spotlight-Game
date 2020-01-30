using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterController : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 15f;
    public float knockbackForce = 5f;
    public GameObject target;
    public AudioSource audioPlayer;
    public AudioClip spawnSound;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.PlayOneShot(spawnSound);
    }

    // Update is called once per frame
    void Update()
    {
        // rotate to look at player
        transform.rotation = Quaternion.Slerp(transform.rotation, 
                                    Quaternion.LookRotation(target.transform.position - transform.position), 
                                    rotationSpeed * Time.deltaTime);

        // walk toward player
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
