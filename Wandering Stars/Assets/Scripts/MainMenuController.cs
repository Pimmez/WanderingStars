using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	public AudioCueEvent audiocue;
	public AudioSource source;

	// Start is called before the first frame update
	private void Start()
	{
		audiocue.Play(source);
	}

	public void Settings()
	{

	}

	public void LoadScene(int _buildIndex)
	{
		SceneManager.LoadScene(_buildIndex);
	}

	public void LoadSceneAsync(int _buildIndex)
	{
		StartCoroutine(LoadYourAsyncScene(_buildIndex));
	}

	IEnumerator LoadYourAsyncScene(int _buildIndex)
	{
		// The Application loads the Scene in the background as the current Scene runs.
		// This is particularly good for creating loading screens.
		// You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
		// a sceneBuildIndex of 1 as shown in Build Settings.

		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_buildIndex);

		// Wait until the asynchronous scene fully loads
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}

	public void Quit()
	{
		Application.Quit();
	}
}