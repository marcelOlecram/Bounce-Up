using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
    /*
     * GAME OVER RULE
     * Player Must Trigger This GameObject
     */
    // public
    public Transform player;
    // private
    private Transform myTransform;    
    private float offset = 10f;

	// Unity Methods
	// Use this for initialization
	void Start () {
        SetInitialReferences();
	}

	void LateUpdate()
    {
        // actualizar posicion acorde a la altura alcanzada
    }

    void OnTriggerEnter(Collider other)
    {
        // juego acaba
        if (other.CompareTag("Player"))
        {
            // call game over event
            Debug.Log("GAME OVER");
        }
        // destuye gameobjects para liberar memoria
        if (other.CompareTag("Platform")){
            Destroy(other.gameObject);
        }
    }

	// My Methods
    void SetInitialReferences()
    {
        myTransform = transform;
        myTransform.position = player.position - new Vector3(0f,offset,0f);
    }
}