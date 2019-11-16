using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycaster : MonoBehaviour
{

    public Text output;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // this makes the destination/direction of the ray cast at the in game location of the mouse 

        RaycastHit hitInfo;// holds all the information about what the ray cast hit

        if (Physics.Raycast(ray, out hitInfo, 500)  == true)// casts the ray as well as checking if it worked
        {
            output.text = hitInfo.transform.gameObject.name; // places the name of the hit gameObject in the text field of the canvas UI
        }
        if (Input.GetMouseButtonDown(0) == true) // checks if the left click on the mouse if being held down
        {
            if (hitInfo.rigidbody.isKinematic == false) // checks if the hit object is dynamic rather than static or non physics
            {
                hitInfo.rigidbody.AddForceAtPosition(ray.direction * 500, hitInfo.point); // uses the hit objects rigid boddy to apply the force, using the direction of the ray 
                                                                                          // as the vector3 force and uses the impact position as the location
            }
            
        }
	}
}
