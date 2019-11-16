using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script just swaps the material depending on if the object is asleep or not

[RequireComponent(typeof(Rigidbody))]
public class PhysicsObject : MonoBehaviour
{

    public Material awakeMaterial = null;
    public Material sleepMaterial = null;

    private Rigidbody _ridgidbody = null;

    bool wasSleeping = false;

	// Use this for initialization
	void Start ()
    {
        _ridgidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void FixedUpdate()
    {
        if (_ridgidbody.IsSleeping() && !wasSleeping && sleepMaterial != null)
        {
            wasSleeping = true;
            GetComponent<MeshRenderer>().material = sleepMaterial; 
        }
        if (!_ridgidbody.IsSleeping() && wasSleeping && awakeMaterial != null)
        {
            wasSleeping = false;
            GetComponent<MeshRenderer>().material = awakeMaterial;
        }
    }
}
