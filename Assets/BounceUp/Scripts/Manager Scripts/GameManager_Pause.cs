using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Pause : MonoBehaviour {

    // public
    // private
    private GameManager gameManager;
    private bool isPaused = false;

	// Unity Methods
    void OnEnable()
    {
        SetInitialReferences();
    }
	// My Methods
    void SetInitialReferences()
    {
        gameManager = GameManager.Instance;
    }

    /// <summary>
    /// Pausar/Continuar el juego. Llamar desde el boton de pausa y  continuar.
    /// </summary>
    public void PauseGame()
    {
        isPaused = !isPaused;
        gameManager.isPause = isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
            gameManager.CallEventPauseGame();
        }else
        {
            Time.timeScale = 1f;
            gameManager.CallEventContinueGame();
        }

    }    
}
