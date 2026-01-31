using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
	public GameState mainMenu;
	public GameState game;
	public GameState paused;
	
	private GameState currentState;
	[Header("References")]
	public LevelSelect LevelSelect;
	public LoadingManager loadingManager;
	[Header("Status")]

	public Level currentLevel;

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
		    if (currentState.menu == mainMenu.menu && newState.menu == game.menu)
		    {
				//start level
				loadingManager.LoadLevel(LevelSelect.selectedLevel);
		    }
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
