using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    // public
    public int score;
    // private
    public GameManager gameManager;

    // Unity Methods
    void Start()
    {
        SetInitialReferences();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(gameManager != null)
            {
                gameManager.IncreaseScore(score);
            }
            // destruir Gameobject
            Destroy(gameObject);
        }
    }
	// My Methods
    void SetInitialReferences()
    {
        gameManager = GameManager.Instance;
    }


}
