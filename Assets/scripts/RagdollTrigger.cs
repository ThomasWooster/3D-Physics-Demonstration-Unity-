using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollTrigger : MonoBehaviour
{

 

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter(Collision collision) // activates when a game phyisics object has a collision rather than when a gameObject enters like the trigger
    {
        Ragdoll ragdoll = collision.gameObject.GetComponentInParent<Ragdoll>();// pulls the ragdoll from the gameObject that collided for refrence

        Animator anim = collision.gameObject.GetComponent<Animator>();// pulls the animator fromt the gameObject that collided for refrence


        if (ragdoll != null) // checking that the ragdoll object it not allready on
        {
            ragdoll.RagdollOn = true; // uses the ragdollOn function to switch from animated to ragdoll  
        }
    }
}
