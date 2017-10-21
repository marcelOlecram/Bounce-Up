using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_UI : MonoBehaviour {

    // public
    public GameObject canvasUIPause;
    public GameObject canvasUIGame;
    // private
    private GameManager gameManager;

	// Unity Methods
    void OnEnable()
    {
        SetInitialReferences();
        gameManager.EventPauseGame += ShowUIPause;
        gameManager.EventContinueGame += HideUIPause;
    }
    void OnDisable()
    {
        gameManager.EventPauseGame -= ShowUIPause;
        gameManager.EventContinueGame -= HideUIPause;
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
}
