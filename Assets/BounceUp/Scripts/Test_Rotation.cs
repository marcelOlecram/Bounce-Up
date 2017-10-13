using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Usar X,Y
/// </summary>
public class Test_Rotation : MonoBehaviour {

    // public
    public Transform cube;
    public GUIText infoX;
    public GUIText infoY;
    public GUIText infoZ;
    // private
    private Gyroscope gyroscope;

    // Unity Methods
    // Use this for initialization
    void Start () {
        SetInitialReferences();
	}
	
	// Update is called once per frame
	void Update () {
        GetRotationInfo();
        
	}

	// My Methods
    void SetInitialReferences()
    {
        gyroscope = Input.gyro;
        gyroscope.enabled = true;
    }

    void GetRotationInfo()
    {
        // rotacion actual
        /*
        infoX.text = "Rotacion X: "+gyroscope.attitude.eulerAngles.x.ToString();
        infoY.text = "Rotacion Y: " + gyroscope.attitude.eulerAngles.y.ToString();
        infoZ.text = "Rotacion Z: " + gyroscope.attitude.eulerAngles.z.ToString();
        cube.rotation = gyroscope.attitude;
        */
        // cambio del angulo actual
        //infoX.text = "Rotacion X: " + gyroscope.rotationRate.x;
        infoY.text = "Rotacion Y: " + gyroscope.rotationRate.y;
        //infoZ.text = "Rotacion Z: " + gyroscope.rotationRate.z;
        //cube.Rotate(gyroscope.rotationRate);
        //cube.Rotate(-gyroscope.rotationRate.x,0f,0f);
        cube.Rotate(0f, -gyroscope.rotationRate.y, 0f);
    }
}