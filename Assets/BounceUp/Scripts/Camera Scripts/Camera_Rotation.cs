using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Rotation : MonoBehaviour {
    #region PublicVariables
    public VirtualJoystick virtualJoystickScript;
    public float rotationSpeed;
    #endregion

    #region PrivateVariables
    private Transform myTrasform;
    #endregion

    #region UnityMethods
    private void Start()
    {
        SetInitialReferences();
    }
    private void Update()
    {
        CheckJoystickInput();
    }
    #endregion

    #region MyMethods
    /// <summary>
    /// Obtiene el input del joystick si se lo usa.
    /// </summary>
    void CheckJoystickInput()
    {
        if (virtualJoystickScript.GetJoystickPosition().x != 0f)
        {
            myTrasform.Rotate(0f,-1*  virtualJoystickScript.GetJoystickPosition().x * Time.deltaTime * rotationSpeed, 0f);
        }
    }

    void SetInitialReferences()
    {
        myTrasform = transform;
    }
    #endregion
}