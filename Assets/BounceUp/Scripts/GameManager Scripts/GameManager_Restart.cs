using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Restart : MonoBehaviour {

    // public
    // private
    private GameManager gameManager;

	// Unity Methods
    void OnEnable()
    {
        SetInitialReferences();
        gameManager.EventRestartGame += RestartGame;
    }

    void OnDisable()
    {
        gameManager.EventRestartGame -= RestartGame;
    }

	// My Methods
    void SetInitialReferences()
    {
        gameManager = GameManager.Instance;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
