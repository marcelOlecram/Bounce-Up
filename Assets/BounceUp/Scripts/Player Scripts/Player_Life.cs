using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Life : MonoBehaviour {

    // public
    public GameManager gameManager;     // unir por inspector. Necesario para GameOver
    public Text lifesUI;
    // private
    private Player playerMaster;
    private int playerLifes;
    private string playerLifeUIText = "V: ";

    // Unity Methods
    void OnEnable()
    {
        SetInitialReferences();
        UpdateUI();
        playerMaster.EventGainLife += GainLife;
        playerMaster.EventLoseLife += LoseLife;
    }

    void OnDisable()
    {
        playerMaster.EventGainLife -= GainLife;
        playerMaster.EventLoseLife -= LoseLife;
    }
	
	// Update is called once per frame
	void Update () {
        //TestLife();
	}

	// My Methods
    void SetInitialReferences()
    {
        playerMaster = GetComponent<Player>();
        playerLifes = playerMaster.playerLifes;
    }

    /// <summary>
    /// Incrementa las vidas en 1, luego actualiza la UI
    /// </summary>
    void GainLife()
    {
        playerLifes++;
        UpdateUI();
    }

    /// <summary>
    /// Decrementa las vidas en 1, luego actualiza la UI
    /// </summary>
    void LoseLife()
    {
        playerLifes--;
        UpdateUI();
        // si las vidas ya son 0
        if (playerLifes<=0)
        {
            gameManager.CallEventGameOver();
        }
    }

    /// <summary>
    /// Actualiza el valor de las vidas en la UI
    /// </summary>
    void UpdateUI()
    {
        lifesUI.text = playerLifeUIText + playerLifes;
    }

    // con fin de pruebas
    void TestLife()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            playerMaster.CallEventLoseLife();
        }
        if (Input.GetKeyUp(KeyCode.N))
        {
            playerMaster.CallEventGainLife();
        }
    }
}
