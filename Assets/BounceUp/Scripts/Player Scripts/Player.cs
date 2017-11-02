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


    #region Delegados
    public delegate void PlayerEventHandler();
    public PlayerEventHandler EventGainLife;            // llamar cuando se gane una vida
    public PlayerEventHandler EventLoseLife;            // llamar cuando se pierda una vida
    //public PlayerEventHandler EventGainPoints;          // llamar cuando se gane puntos por los collectable
    //public PlayerEventHandler EventMaxHeight;           // llamar cuando se consiga nueva altura maxima

    public delegate void PlayerPointsEventHandler(int score);
    public PlayerPointsEventHandler EventGainPoints;    // llamar cuando se gane puntos por los collectable

    public delegate void PlayerHeightEventHandler(float height);
    public PlayerHeightEventHandler EventMaxHeight;     // llamar cuando se consiga nueva altura maxima
    #endregion Delegados
    // Unity Methods
    void OnEnable()
    {
        StartFromZero();
    }

    // My Methods

    public void CallEventGainLife()
    {
        if(EventGainLife != null)
        {
            EventGainLife();
        }
    }

    public void CallEventLoseLife()
    {
        if (EventLoseLife != null)
        {
            EventLoseLife();
        }
    }

    public void CallEventGainPoints(int score)
    {
        if (EventGainPoints!= null)
        {
            EventGainPoints(score);
        }
    }

    public void CallEventMaxHeight(float height)
    {
        if(EventMaxHeight!= null)
        {
            EventMaxHeight(height);
        }
    }

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
