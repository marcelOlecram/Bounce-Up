using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Bounce : MonoBehaviour {

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
        Debug.Log("collision plataforma");
        //Debug.Log(col.contacts.Length);
        //Debug.Log(col.contacts[0].point);
        //Debug.Log(col.contacts[0].normal);
        //Debug.DrawRay(col.contacts[0].point, col.contacts[0].normal,Color.red,5f);
        reflectDirection = Vector3.Reflect(col.rigidbody.velocity, col.contacts[0].normal);
        reflectDirection.Normalize();
        Debug.DrawRay(col.contacts[0].point, Vector3.Reflect(col.relativeVelocity, col.contacts[0].normal), Color.red, 5f);
        //col.rigidbody.velocity = Vector3.zero;
        
    }
    void OnCollisionExit(Collision col)
    {
        
        col.rigidbody.AddForce(reflectDirection * 100f, ForceMode.Impulse);
    }
	// My Methods
}
