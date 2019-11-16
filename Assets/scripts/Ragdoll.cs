using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ragdoll : MonoBehaviour
{

    private Animator animator = null; // holds the animator of the parent
    public List<Rigidbody> rigidBodys = new List<Rigidbody>(); // holds all the rigid bodys for all the ragdoll bones

    public bool RagdollOn // this function switches between animation mode and ragdoll mode
    {
        get { return !animator.enabled; } // returns wether the ragdoll is on or not 
        set
        {
            animator.enabled = !value; // because the animator is for the animation mode and is opposite of the ragdoll which this function controlles it will be set as such
            foreach (Rigidbody r in rigidBodys) // itterates through all the ragdolles in the modell
            {
                r.isKinematic = !value; // as kinematic is static and opposite of what we want we set the value as such
            }
        }
    }

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>(); // takes the animator from the parent

        foreach(Rigidbody r in rigidBodys)
        {
            r.isKinematic = true; // makes sure that at the start all of the rigid bodys are in animate mode
        }

        RagdollOn = false; // sets the ragdoll to animate mode or off
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
