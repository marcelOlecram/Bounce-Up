using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Player : MonoBehaviour {

    // public
    // private
    private Vector3 reflectDirection;
	// Unity Methods
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("Collision jugador");
    }
    void OnCollisionExit(Collision col)
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collider jugador");
    }

	// My Methods
}
