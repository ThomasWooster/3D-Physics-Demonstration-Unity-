using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is the animated player controled script
[RequireComponent (typeof(CharacterController))]
[RequireComponent (typeof(Animator))]
public class Player : MonoBehaviour
{

    CharacterController controller = null; // holds a refrence to the parent CharacterController
    Animator animator = null; // holds a refrence to the parent Animator

    public float speed = 80.0f; // the speed at which the animation playes as well as the player moves
    public float pushPower = 2.0f; // the pushing force of the player charicter


	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<CharacterController>(); // gets the CharacterController from the parent
        animator = GetComponent<Animator>(); // gets the animator from the parent
	}
	
	// Update is called once per frame
	void Update ()
    {
        float vertical = Input.GetAxis("Vertical"); // gets a refrence to the value of the vertical imput
        float horizontal = Input.GetAxis("Horizontal"); // gets a refrence to the value of the horizontal imput

        
        controller.SimpleMove(transform.up * Time.deltaTime); // simple move allows for the calculation of gravity 
        transform.Rotate(transform.up, horizontal * speed * Time.deltaTime); // this rotates the player around the y axis at speed
        animator.SetFloat("Speed", vertical * speed * Time.deltaTime);// this sets the float of the animator whish controles the speed of the animation, 
                                                                      // the animator has apply root motion meaning that the animation is how the player moves
                                                                      // as the vertical axis is multiplyed in if you don't hold down 'w' then vertical = 0
	}


    private void OnControllerColliderHit(ControllerColliderHit hit) // this controles collisions whith dynamic objects
    {
        Rigidbody body = hit.collider.attachedRigidbody; // holds a refrence tot he rigid body of the object th player collided with
        if (body == null || body.isKinematic) // it does not have a rigid body or it is a static object dont do anything
        {
            return;
        }
        if (hit.moveDirection.y < -0.3f) // if the y axis movment is less that -0.3f dont do anything
        {
            return;
        }
         //otherwise 
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z); // this gets the direction of your movement as the direction of push
        body.velocity = pushDir * pushPower; // the other objects velocity becomes the push direction x the playews push power
    }
}
