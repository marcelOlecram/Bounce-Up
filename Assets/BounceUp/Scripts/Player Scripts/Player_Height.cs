using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Height : MonoBehaviour {

    // public
    public Text maxHeightUI;
    public Text currentHeightUI;
    // private
    private Player playerMaster;
    private string playerCurrentHeightUIText = "H: ";
    private string playerMaxHeightUIText = "Hm: ";
    private float maxHeight = -0.1f;
    private float currentHeight;

	// Unity Methods
    void OnEnable()
    {
        SetInitialReferences();
        UpdateUI();
        playerMaster.EventMaxHeight += SetNewMaxHeight;
    }

    void OnDisable()
    {
        playerMaster.EventMaxHeight += SetNewMaxHeight;
    }

    void LateUpdate()
    {
        CheckHeight();
    }

	// My Methods
    void SetInitialReferences()
    {
        playerMaster = GetComponent<Player>();
    }

    /// <summary>
    /// Revisar si la altura actual es mayor a la mas alta registrada
    /// </summary>
    void CheckHeight()
    {
        // update current ui localy
        currentHeight = transform.position.y;
        currentHeightUI.text = playerCurrentHeightUIText + currentHeight.ToString("F2");
        // check max ui changes
        if(currentHeight > maxHeight)
        {
            // llamar playerMaster
            playerMaster.CallEventMaxHeight(currentHeight);
        }
    }

    /// <summary>
    /// Cambia el valor de la altura maxima alcanzada. Luego actualiza la UI.
    /// </summary>
    /// <param name="height"></param>
    void SetNewMaxHeight(float height)
    {
        maxHeight = height;
        UpdateUI();
    }

    /// <summary>
    /// Actualiza el valor de la altura maxima en la UI
    /// </summary>
    void UpdateUI()
    {
        maxHeightUI.text = playerMaxHeightUIText + maxHeight.ToString("F2");
    }

    /// <summary>
    /// Retorna la altura maxima actual
    /// </summary>
    /// <returns></returns>
    public float GetMaxHeight() { return maxHeight; }
}
