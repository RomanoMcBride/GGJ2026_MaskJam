using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider progressBar;
    public Level currentLevel;

    public void LoadLevel(Level level)
    {
	    currentLevel = level;
        StartCoroutine(LoadAsynchronously(level.levelFileName));
        
    }
    
    
    IEnumerator LoadAsynchronously(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);


	    loadingScreen.SetActive(true);

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress);

	        progressBar.value = progress;
            
            operation.allowSceneActivation = true;

            yield return null;
        }

	    loadingScreen.SetActive(false);
    }
}