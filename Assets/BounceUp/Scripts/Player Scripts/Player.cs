using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // public
    [Header("Player Data")]
    public int playerLifes;
    public int playerScore;
    public float playerHeigth;
    // private


    // Unity Methods

    /// <summary>
    /// Resetea las variables para iniciar desde 0.
    /// </summary>
    public void StartFromZero()
    {
        playerLifes = 3;
        playerScore = 0;
        playerHeigth = 0f;
    }
}
