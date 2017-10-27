using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_GameOver : MonoBehaviour {

    // public
    // private
    private GameManager gameManager;

	// Unity Methods	
    void OnEnable()
    {
        gameManager = GameManager.Instance;
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyUp(KeyCode.K))
        {
            Debug.Log("GameOVer");
            gameManager.CallEventGameOver();
        }
	}

	// My Methods
}
