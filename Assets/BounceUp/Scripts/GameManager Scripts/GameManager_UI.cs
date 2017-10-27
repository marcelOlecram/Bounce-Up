using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_UI : MonoBehaviour {

    // public
    public GameObject canvasUIPause;
    public GameObject canvasUIGame;
    public GameObject canvasUIGameOver;
    // private
    private GameManager gameManager;

	// Unity Methods
    void OnEnable()
    {
        SetInitialReferences();
        gameManager.EventPauseGame += ShowUIPause;
        gameManager.EventContinueGame += HideUIPause;
        gameManager.EventGameOver += ShowUIGameOver;
    }
    void OnDisable()
    {
        gameManager.EventPauseGame -= ShowUIPause;
        gameManager.EventContinueGame -= HideUIPause;
        gameManager.EventGameOver -= ShowUIGameOver;
    }

	// My Methods
    void SetInitialReferences()
    {
        gameManager = GameManager.Instance;
    }

    void ShowUIPause()
    {
        canvasUIPause.SetActive(true);
        canvasUIGame.SetActive(false);
    }

    void HideUIPause()
    {
        canvasUIPause.SetActive(false);
        canvasUIGame.SetActive(true);
    }

    void ShowUIGameOver()
    {
        canvasUIGameOver.SetActive(true);
        canvasUIGame.SetActive(false);
    }
}
