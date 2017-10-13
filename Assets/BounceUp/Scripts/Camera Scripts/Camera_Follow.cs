using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {

    // public
    public Transform player;
    // private
    private Transform myTransform;
    [SerializeField]
    private Vector3 offset;

	// Unity Methods
	// Use this for initialization
	void Start () {
        SetInitialReferences();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        FollowPlayer();
    }

	// My Methods
    void SetInitialReferences()
    {
        // transform
        myTransform = transform;
        // camera offset
        //offset =  transform.TransformDirection(0f, 1f, -3f);
        myTransform.LookAt(player);
    }

    void FollowPlayer()
    {
        //myTransform.LookAt(player);
        myTransform.position = player.position + offset;
    }
}