using UnityEngine;

public class GoToMenu : MonoBehaviour
{
	public void GoToMainMenu()
	{
		GameStateManager m =  FindFirstObjectByType<GameStateManager>();
		m.ChangeState("main");
	}
}
