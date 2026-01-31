using System;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
	private GameStateManager stateManager;
    void Start()
    {
        stateManager = FindFirstObjectByType(typeof(GameStateManager)) as GameStateManager;
    }


    private void OnTriggerEnter(Collider other)
    {
	    if (stateManager)
	    {
		    if (other.gameObject.name == "Player")
		    {
			    stateManager.ChangeState("levelCompleted");
		    }
	    }
	    else
	    {
		    Debug.Log("Level completed. No game state manager found. This could be because the level has been started directly, without the main menu");
	    }
    }
}
