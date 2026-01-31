using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


public class LevelSelect : MonoBehaviour
{
	[Header("settings")]
	public Level[] availableLevels;
	[Header("references")]
	public TMP_Dropdown dropdown;

	public Image previewImage;
	public TextMeshProUGUI levelName;

    void Start()
    {
	    dropdown.ClearOptions();
	    // Update the level list
		List<string> levelNames = new List<string>();
		foreach (Level level in availableLevels)
		{
			levelNames.Add(level.levelName);
			
		}
        
	    dropdown.AddOptions(levelNames);
	    
	    dropdown.onValueChanged.AddListener(OnLevelSelected);
		// Select the first level
		OnLevelSelected(0);
    }
    
    void OnLevelSelected(int index)
    {
	    Level selectedLevel = availableLevels[index];
	    //change the preview to reflect the level
	    previewImage.sprite = selectedLevel.levelPreviewImage;
	    levelName.text = selectedLevel.levelName;
    }

    void OnDestroy()
    {
	    // Clean up the listener
	    dropdown.onValueChanged.RemoveListener(OnLevelSelected);
    }
}
