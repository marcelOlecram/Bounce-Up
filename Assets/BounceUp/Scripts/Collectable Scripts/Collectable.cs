using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	// public
	// private

	// Unity Methods

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // aumentar puntaje
                // llamar a un manager
            // destruir Gameobject
            Destroy(gameObject);
        }
    }
	// My Methods
}
