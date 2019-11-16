using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    public GameObject cannonBallPrefab = null; // holds a refrece to that the cannon will fire
    public Transform spawnPoint = null; // holds a refrence to the location of the spawning
    public float forceOnFire = 1200; // the forece applyed upon the spawned object in order to fire it 
    public float cooldownTime = 0.2f; // the rate of fire

    float cooldownTimer = 0; // the current cool down time

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.anyKeyDown && cooldownTimer <= 0) // if any mouse/keyboard input and the timer has 'cooled down'
        {
            GameObject go = Instantiate(cannonBallPrefab, spawnPoint.position, spawnPoint.rotation); // holds the spawned object for refrence

            if (go == null) // if it failed to spawn
            {
                return;
            }

            Rigidbody rb = go.GetComponent<Rigidbody>(); // gets the rigid body 
            if (rb == null)// if the rigid body dosent exist 
            {
                return;
            }

            rb.AddForce(go.transform.forward * forceOnFire); // applys the forece to the spawned object in the direction of the spawner
            cooldownTimer = cooldownTime; // resets the ccool down
        }

        if (cooldownTimer > 0) // if the timer is going it tickes in down
        {
            cooldownTimer -= Time.deltaTime; 
        }
	}
}
