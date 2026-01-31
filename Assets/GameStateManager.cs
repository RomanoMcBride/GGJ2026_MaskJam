using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
	public GameState mainMenu;
	public GameState game;
	public GameState paused;
	public GameState levelCompleted;
	public GameState gameOver;
	
	private GameState currentState;
	[Header("References")]
	public LevelSelect LevelSelect;
	public LoadingManager loadingManager;
	//[Header("Status")]
	private float levelStartTime;
	private float levelCompletionTime;

	private void Awake()
	{
		DontDestroyOnLoad(this);
	}

	void Start()
    {
	    currentState = mainMenu; //default is main menu
	    game.menu.SetActive(false);
	    paused.menu.SetActive(false);
		levelCompleted.menu.SetActive(false);
		gameOver.menu.SetActive(false);
    }


    public void ChangeState(GameState newState)
    {
	    Time.timeScale = newState.gameSpeed;
	    Debug.Log("changing state:"+ newState.menu.ToString());
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
		    case "levelCompleted":
			    ChangeState(levelCompleted);
			    break;
		    case "gameOver":
			    ChangeState(gameOver);
			    break;
		    default:
			    Debug.LogWarning("unknown state. going to main menu");
			    ChangeState(mainMenu);
			    break;
	    }
    }

    public void RestartLevel()
    {
	    ChangeState(game);
	    loadingManager.LoadLevel(LevelSelect.selectedLevel);
    }
    
    public void LoadNextLevel()
    {
	    ChangeState(game);
	    loadingManager.LoadLevel(loadingManager.currentLevel.nextLevel);
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
	public float gameSpeed; //the speed at this state
}
