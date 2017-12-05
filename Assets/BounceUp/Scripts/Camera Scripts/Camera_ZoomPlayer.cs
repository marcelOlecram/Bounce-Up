using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_ZoomPlayer : MonoBehaviour {

    #region PublicVariables
    public Transform playerTransform;
    public float minDistance;
    public float maxDistance;
    public float zoomSpeed;
    public VirtualJoystick virtualJoystickScript;
    #endregion

    #region PrivateVariables
    private Transform myTransform;
    #endregion

    #region UnityMethods   
    // Update is called once per frame
    private void Start()
    {
        SetInitialReferences();
        LookAtPlayer();
    }
    private void Update()
    {
        //CheckForZoomInput();
        // TODO revisar el acercamiento
    }

    private void LateUpdate()
    {
        LookAtPlayer();
    }
    #endregion

    #region myMethods
    void CheckForZoomInput()
    {
        if (virtualJoystickScript.GetJoystickPosition().y != 0f)
        {
            float x = virtualJoystickScript.GetJoystickPosition().y;
            myTransform.position += (x * Time.deltaTime * zoomSpeed) * myTransform.forward;
            myTransform.localPosition = new Vector3(myTransform.localPosition.x,
                                                    myTransform.localPosition.y,
                                                    Mathf.Clamp(myTransform.localPosition.z, minDistance, maxDistance));            
        }
    }

    void SetInitialReferences()
    {
        myTransform = transform;
    }

    void LookAtPlayer()
    {
        myTransform.LookAt(playerTransform);
    }
    #endregion
}
