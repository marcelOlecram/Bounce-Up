using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Score : MonoBehaviour {

    // public
    public int lifes;
    public int points;    
    public float yMax = 0f;
    // private


    // Unity Methods
	
	void LateUpdate () {
        CheckMaximumHeight();
	}

	// My Methods
    void SetInitialReferences()
    {

    }

    void CheckMaximumHeight()
    {
        if(transform.position.y > yMax)
        {
            yMax = transform.position.y;
        }
    }
}
