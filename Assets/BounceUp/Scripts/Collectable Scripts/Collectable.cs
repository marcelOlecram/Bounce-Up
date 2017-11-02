using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    // public
    public int score;
    // private

    // Unity Methods
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // destruir Gameobject
            Destroy(gameObject);
        }
    }
	// My Methods
}