using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_GoToMenu : MonoBehaviour {

    // public
    // private
    private GameManager gameManager;

	// Unity Methods
    void OnEnable()
    {
        SetInitialReferences();
        gameManager.EventGoToMenu += GoToMenuScene;
    }

    void OnDisable()
    {
        gameManager.EventGoToMenu -= GoToMenuScene;
    }

	// My Methods
    void SetInitialReferences()
    {
        gameManager = GameManager.Instance;
    }

    void GoToMenuScene()
    {
        SceneManager.LoadScene(0); // menu es la escena 0
    }
}
