using System;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
	public GameState mainMenu;
	public GameState game;
	public GameState paused;
	
	private GameState currentState;

	private void Awake()
	{
		DontDestroyOnLoad(this);
	}

	void Start()
    {
	    currentState = mainMenu; //default is main menu
	    game.menu.SetActive(false);
	    paused.menu.SetActive(false);
    }


    public void ChangeState(GameState newState)
    {
	    Debug.Log(newState.menu.ToString());
	    if (currentState.menu)
	    {
		    Debug.Log("disabling" +  currentState.menu);
		    currentState.menu.SetActive(false);
	    }

	    if (newState.menu)
	    {
		    newState.menu.SetActive(true);
		    currentState = newState;
	    }
    }

    public void ChangeState(string newState)
    {
	    switch (newState)
	    {
		    case "main":
			    ChangeState(mainMenu);
			    break;
		    case "game":
			    ChangeState(game);
			    break;
		    case "paused":
			    ChangeState(paused);
			    break;
		    default:
			    ChangeState(mainMenu);
			    break;
	    }
    }
    
    void LoadLevel()
    {
	    
    }

    public void QuitGame()
    {
	    Application.Quit();
    }
}

[System.Serializable]
public struct GameState
{
	public GameObject menu;
}
