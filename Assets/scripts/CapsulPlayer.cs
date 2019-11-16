using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the capsule that the player controles
[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(CharacterController))]
public class CapsulPlayer : MonoBehaviour
{

    Camera dave = null; // holds a refrence to the main camera that is a child of the capsule 
    CharacterController controller = null; // holds a refrece tot he CharicterController of the parent

    public float speed = 80.0f; // the movemet speed of the player
    public float pushPower = 2.0f; // the pushing power of the player

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>(); // gets the Charicter controler from the parent
        dave = GetComponentInChildren<Camera>(); // gets the camera from the parent
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical"); // input 'w', 's'
        float turning = Input.GetAxis("Mouse X"); // input of mouse x axis
        float strafing = Input.GetAxis("Horizontal"); // input 'a', 'd'
        //float lookUp = Input.GetAxis("Mouse Y"); // input of mouse y axis // not currently used

        controller.SimpleMove(transform.forward * vertical * speed * Time.deltaTime); // simople move allowes for gravity and collision// this one is for moving forward
        controller.SimpleMove(transform.right * strafing * speed * Time.deltaTime); // this simple move controles strafing
        transform.Rotate(transform.up, turning * speed * Time.deltaTime); // rotation of the player based on mouse movment
        

    }


    private void OnControllerColliderHit(ControllerColliderHit hit) // this controles collision with dynamic objects 
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

