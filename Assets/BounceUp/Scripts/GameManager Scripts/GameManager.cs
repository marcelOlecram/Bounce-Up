using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Esta clase controlara, el puntaje, estado del juego etc.
 HAcerlo singleton*/
public class GameManager : MonoBehaviour {

    // public
    /*
    [Header("Player Data")]
    public int playerLifes;
    public int playerScore;
    public float playerHeigth;
    */
    [Header("Game Data")]
    public bool isPause = false;
    public bool isGameOver = false;
    /*
    [Header("Dependencias")]
    public Player_Controller playerController;
    */
    // private
    // isntancia
    private static GameManager _instancia = null;

    #region Delegados
    public delegate void GameManagerEventHandler();
    public GameManagerEventHandler EventPauseGame;      // llamarlo cuando el juego este en pausa
    public GameManagerEventHandler EventContinueGame;   // llamarlo cuando el juego deje de estar en pausa
    public GameManagerEventHandler EventRestartGame;    // llamarlo cuando se desee reiniciar el nivel
    public GameManagerEventHandler EventGoToMenu;       // llamarlo cuando se desee ir al menu
    public GameManagerEventHandler EventGameOver;       // llamarlo cuando se acaben las vidas
    #endregion Delegados

    // Unity Methods
    // Use this for initialization
    void Awake () {
		if(_instancia == null)
        {
            _instancia = this;
        }
	}

    // My Methods
    public static GameManager Instance
    {
        get
        {
            if(_instancia == null)
            {
                _instancia = Object.FindObjectOfType(typeof(GameManager)) as GameManager;
                if(_instancia == null)
                {
                    GameObject gO = new GameObject("GameManager");
                    DontDestroyOnLoad(gO);
                    _instancia = gO.AddComponent<GameManager>();
                }
            }
            return _instancia;
        }
    }

    public void CallEventPauseGame()
    {
        if(EventPauseGame != null)
        {
            // llamar a metodos suscritos a este evento. Ej: mostrar menu, disable player movement, etc.
            EventPauseGame();
        }
    }

    public void CallEventContinueGame()
    {
        if (EventContinueGame != null)
        {
            EventContinueGame();
        }
    }

    public void CallEventRestartGame()
    {
        if(EventRestartGame != null)
        {
            Time.timeScale = 1f;
            EventRestartGame();
        }
    }

    public void CallEventGoToMenu()
    {
        if (EventGoToMenu != null)
        {
            EventGoToMenu();
        }
    }

    public void CallEventGameOver()
    {
        if (EventGameOver != null)
        {
            EventGameOver();
        }
    }
}
