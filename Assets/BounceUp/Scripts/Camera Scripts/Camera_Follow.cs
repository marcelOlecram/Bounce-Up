using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {

    // public
    [Tooltip("the transform to look at.")]
    public Transform player;
    public VirtualJoystick virtualJoysctickScript;
    public float distanceDamp;
    // private
    private float cameraSpeed = 5f;
    private Transform myTransform;
    [SerializeField]
    private Vector3 offset;
    private Vector3 velocity = Vector3.one;

	// Unity Methods
	// Use this for initialization
	void Start () {
        SetInitialReferences();
	}

    void FixedUpdate()
    {
        CheckJoystickInput();
        SmoothFollow();
        FollowPlayer();        
    }

	// My Methods
    void SetInitialReferences()
    {
        // transform
        myTransform = transform;        
        myTransform.LookAt(player);
    }

    /// <summary>
    /// Mira al jugador. Rota el transform para mirar al jugador.
    /// </summary>
    void FollowPlayer()
    {
        myTransform.LookAt(player.transform);
    }

    /// <summary>
    /// Obtiene el input del joystick si se lo usa.
    /// </summary>
    void CheckJoystickInput()
    {
        if(virtualJoysctickScript.GetJoystickPosition() != Vector3.zero)
        {
            Vector3 direction = new Vector3(virtualJoysctickScript.GetJoystickPosition().x, virtualJoysctickScript.GetJoystickPosition().y,0f);
            Vector3 velocidad = direction * cameraSpeed * Time.deltaTime;
            /*velocidad = myTransform.TransformDirection(velocidad);
            velocidad.y = direction.y * cameraSpeed * Time.deltaTime;
            myTransform.position += velocidad;*/            
            offset += velocidad;
            // limitar los movimientos verticales del joystick
            offset.y = Mathf.Clamp(offset.y, 0f, 10f);
        }
    }

    /// <summary>
    /// Mantiene a la camara cerca del jugador, fluidamente.
    /// </summary>
    void SmoothFollow()
    {
        Vector3 toPosition = player.position + offset;
        Vector3 currentPosition = Vector3.SmoothDamp(myTransform.position, toPosition, ref velocity, distanceDamp);
        myTransform.position = currentPosition;
        // mirar al jugador
        FollowPlayer();
    }
}