using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_FollowPlayer : MonoBehaviour {

    #region PublicVariables
    public Transform playerTransform;
    public float distanceDamp;
    #endregion

    #region PrivateVariables
    private Vector3 velocity = Vector3.one;
    private Transform myTransform;
    #endregion

    #region UnityMethods   
    private void Start()
    {
        SetInitialReferences();        
    }

    private void FixedUpdate () {
        SmoothFollow();
	}
    #endregion

    #region myMethods
    /// <summary>
    /// Mantiene a la camara cerca del jugador, fluidamente.
    /// </summary>
    void SmoothFollow()
    {
        Vector3 toPosition = playerTransform.position;
        Vector3 currentPosition = Vector3.SmoothDamp(transform.position, toPosition, ref velocity, distanceDamp);
        transform.position = currentPosition;
    }

    void SetInitialReferences()
    {
        myTransform = transform;
    }
    #endregion
}
