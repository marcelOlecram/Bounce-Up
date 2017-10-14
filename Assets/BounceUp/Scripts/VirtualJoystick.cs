using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {


    // public
    // private
    private Image backgroundImage;
    private Image joystick;
    private Vector3 inputVector;

    // Unity Methods
    // Use this for initialization
    void Start () {
        SetInitialReferences();
	}

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroundImage.rectTransform,eventData.position, eventData.pressEventCamera, out position))
        {
            // calcular la posicion del toque dentro el joystick
            // convertirla en rango de 0-1
            position.x = (position.x / backgroundImage.rectTransform.sizeDelta.x);
            position.y = (position.y / backgroundImage.rectTransform.sizeDelta.y);
            float x = (backgroundImage.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1; // esto se debe a los anchors de la imagen
            float y = (backgroundImage.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;
            inputVector = new Vector3(x, y);             
            inputVector = inputVector.magnitude > 1 ? inputVector.normalized : inputVector;
            //Debug.Log(inputVector);
            // mover el josytick
            joystick.rectTransform.anchoredPosition = new Vector3(inputVector.x * backgroundImage.rectTransform.sizeDelta.x / 3, inputVector.y * backgroundImage.rectTransform.sizeDelta.y / 3);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
    }

    // My Methods

    void SetInitialReferences()
    {
        // obtener referencia a las imagenes
        backgroundImage = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    /// <summary>
    /// Obtiene la posicion del joystick. En un Vector3
    /// </summary>
    /// <returns>Vector 3, almacenando en X y Y la posicion del joystick. </returns>
    public Vector3 GetJoystickPosition()
    {
        return inputVector;
    }
}
