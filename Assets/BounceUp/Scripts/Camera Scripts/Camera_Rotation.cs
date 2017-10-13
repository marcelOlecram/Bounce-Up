using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Rotation : MonoBehaviour {

    // public
    public Transform player;
    public RectTransform joystickArea;
    // private
    private Vector3 firstPoint;
    private Vector3 secondPoint;
    private float xAngle = 0f;
    private float yAngle = 0f;

    // Unity Methods
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckTouchInput();
	}

	// My Methods
    void SetInitialReferences()
    {
        transform.rotation = Quaternion.Euler(yAngle, xAngle, 0f);
    }

    void CheckTouchInput()
    {
        // si hay touch en pantalla
        if(Input.touchCount > 0)
        {
            Touch mTouch = Input.GetTouch(0);
            // guardar posicion y angulos
            if (mTouch.phase == TouchPhase.Began)
            {
                firstPoint = mTouch.position;
            }
            if (mTouch.phase == TouchPhase.Moved)
            {
                secondPoint = mTouch.position;
                xAngle = -(secondPoint.x - firstPoint.x)/ Screen.width;
                //transform.RotateAround(player.position, new Vector3(1f, 0f, 0f), yAngle);
                transform.Rotate(0f, xAngle, 0f);
            }
        }
    }
}