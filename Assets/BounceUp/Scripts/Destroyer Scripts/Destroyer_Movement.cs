using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer_Movement : MonoBehaviour {

    // public
    public float yOffset;
    // private
    private Transform myTrasform;
    private GameObject playerGO;    
    private Transform playerTransform;

    // Unity Methods
    void OnEnable()
    {
        SetInitialReferences();
    }
    // Use this for initialization
    void Start () {
        SetInitialReferences();
	}

    void LateUpdate()
    {
        myTrasform.position = new Vector3(playerTransform.position.x, 
                                          playerGO.GetComponent<Player_Height>().GetMaxHeight() + yOffset, 
                                          playerTransform.position.z);    
    }

    // My Methods
    void SetInitialReferences()
    {
        if(playerGO == null)
        {
            playerGO = GameObject.FindGameObjectWithTag("Player");
        }
        if(playerTransform == null)
        {
            playerTransform = playerGO.transform;
        }
        myTrasform = transform;
    }
}
