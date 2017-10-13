﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    // public
    public float speed;
    public VirtualJoystick virtualJoystickScript;
    // private
    private Gyroscope gyroscope;
    private Rigidbody myRigidbody;
    //private Transform myTransform;

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
        //CheckRotationInput();
        CheckJoystickInput();
    }

	// My Methods

    void SetInitialReferences()
    {
        // gyroscopio
        gyroscope = Input.gyro;
        gyroscope.enabled = true;
        // rigidbody
        myRigidbody = GetComponent<Rigidbody>();
        // transform
        //myTransform = transform;
    }

    /// <summary>
    /// Incrementa la velocidad en base al gyroscopio del dispositivo
    /// </summary>
    void CheckRotationInput()
    {
        //Debug.DrawLine(myTransform.position, myTransform.forward,Color.red);
        //Vector3 vel = new Vector3(-gyroscope.rotationRate.x * speed * Time.deltaTime, 0f, -gyroscope.rotationRate.y * speed * Time.deltaTime);        
        Vector3 vel = new Vector3(gyroscope.rotationRate.y * speed * Time.deltaTime, 0f, -gyroscope.rotationRate.x * speed * Time.deltaTime);
        //Vector3 vel = myTransform.TransformDirection(-gyroscope.rotationRate.y * speed * Time.deltaTime, 0f, -gyroscope.rotationRate.x * speed * Time.deltaTime);
        myRigidbody.velocity += vel;
    }

    void CheckJoystickInput()
    {
        Vector3 direction = new Vector3(virtualJoystickScript.GetJoystickPosition().x,0f, virtualJoystickScript.GetJoystickPosition().y);
        //Debug.DrawLine(Vector3.zero,direction);
        Vector3 velocidad = direction * speed * Time.deltaTime ;
        //Debug.DrawLine(Vector3.zero, velocidad*5, Color.blue);
        velocidad = Camera.main.transform.TransformDirection(velocidad);
        //Debug.DrawLine(Camera.main.transform.position, velocidad*5,Color.red);
        myRigidbody.velocity += velocidad;
    }
}