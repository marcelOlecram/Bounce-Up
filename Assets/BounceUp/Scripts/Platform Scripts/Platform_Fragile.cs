using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Fragile : MonoBehaviour {

    // public
    public int bounceLimit;
    [Space(5)]
    public Material fragileMaterial;
    // private
    private int currentBounce = 0;

	// Unity Methods
	// Use this for initialization
	void Start () {
        
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            currentBounce++;
            if(currentBounce == bounceLimit - 1)
            {
                GetComponent<Renderer>().material = fragileMaterial;
            }
            if(currentBounce >= bounceLimit)
            {
                Destroy(gameObject);
            }
        }
    }

	// My Methods

    void SetInitialReferences()
    {

    }
}