using UnityEngine;
using UnityEngine.InputSystem;

public class OpenPause : MonoBehaviour
{
	public InputActionReference pause;
	public GameStateManager game;

    void OnEnable()
    {
	    pause.action.performed += OnPause;
	    pause.action.Enable();
    }

    void OnDisable()
    {
	    pause.action.performed -= OnPause;
    }

    void OnPause(InputAction.CallbackContext context)
    {
	    if (game)
	    {
		    game.ChangeState("paused");
	    }
	    else
	    {
		    Debug.LogError("pause menu can't find game state manager.");
	    }
    }
}
