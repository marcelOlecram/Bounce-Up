using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Points : MonoBehaviour {

    // public
    public Text scoreUI;
    // private
    private Player playerMaster;
    private int playerScore = 0;
    private string playerScoreUIText = "P: ";

	// Unity Methods
    void OnEnable()
    {
        SetInitialReferences();
        UpdateUI();
        playerMaster.EventGainPoints += IncreaseScore;
    }

    void OnDisable()
    {
        playerMaster.EventGainPoints -= IncreaseScore;
    }
	
    void OnTriggerEnter(Collider other)
    {
        // si en entra en contacto con un Collectable
        if (other.CompareTag("Collectable"))
        {
            // si el collectable tiene su respectivo script
            if(other.GetComponent<Collectable>() != null)
            {
                // llamar al PlayerMaster para incremetar el puntaje
                playerMaster.CallEventGainPoints(other.GetComponent<Collectable>().score);
            }
        }
    }

	// My Methods
    void SetInitialReferences()
    {
        playerMaster = GetComponent<Player>();
    }

    /// <summary>
    /// Actualiza el valor del puntaje en la UI
    /// </summary>
    void UpdateUI()
    {
        scoreUI.text = playerScoreUIText + playerScore;
    }

    /// <summary>
    /// Incrementa el puntaje. Luego actualiza la UI
    /// </summary>
    /// <param name="score">Puntaje a incrementar</param>
    void IncreaseScore(int score)
    {
        playerScore += score;
        UpdateUI();
    }
}
