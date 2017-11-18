using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer_Player : MonoBehaviour {

    // public
    // private
    private Player playerMaster;

    // Unity Methods
    void OnEnable()
    {
        SetInitialReferences();       
    }

    // Use this for initialization
    void Start () {
        SetInitialReferences();
	}

	// My Methods
    void SetInitialReferences()
    {
        if(playerMaster == null)
        {
            playerMaster = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // verificar si el Player entro en el colider
        if (other.CompareTag("Player"))
        {
            playerMaster.CallEventLoseLife();       // llamar al evento de perdida de vida
        }
    }
}
