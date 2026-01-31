using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


public class LevelSelect : MonoBehaviour
{
	public Level[] availableLevels;
	public TMP_Dropdown dropdown;
    void Start()
    {
	    dropdown.ClearOptions();
	    //update the level list
		List<string> levelNames = new List<string>();
		foreach (Level level in availableLevels)
		{
			levelNames.Add(level.levelName);
			
		}
        
	    dropdown.AddOptions(levelNames);
	    
	    dropdown.onValueChanged.AddListener(OnLevelSelected);

    }
    
    void OnLevelSelected(int index)
    {
	    Level selectedLevel = availableLevels[index];
	    Debug.Log($"Selected level: {selectedLevel.levelName} (ID: {selectedLevel.levelID})");
    }

    void OnDestroy()
    {
	    // Clean up the listener
	    dropdown.onValueChanged.RemoveListener(OnLevelSelected);
    }
}
