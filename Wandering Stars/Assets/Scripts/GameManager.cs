using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

#region SINGLETON PATTERN
	public static GameManager instance;
	public static GameManager Instance { get { return instance; } }

	private void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			instance = this;
		}
	}
	#endregion

	public AudioCueEvent audiocue;
	public AudioSource source;

	[SerializeField] private GameObject pauseMenu;
	[SerializeField] private GameObject gameOverMenu;
	[SerializeField] private GameObject HUDMenu;
	[SerializeField] private GameObject settingsMenu;

	private void Start()
	{
		audiocue.Play(source);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			if (!pauseMenu.activeInHierarchy)
			{
				PauseMenu();
			}
		}
	}


	/// <summary>
	/// UI
	/// </summary>

	private void PauseMenu()
	{
		HUDMenu.SetActive(false);
		pauseMenu.SetActive(true);
	}

	public void ResumeGame()
	{
		HUDMenu.SetActive(true);
		pauseMenu.SetActive(false);
	}

	public void SettingsMenu()
	{
		pauseMenu.SetActive(false);
		settingsMenu.SetActive(true);
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

	public void GameOver()
	{
		HUDMenu.SetActive(false);
		gameOverMenu.SetActive(true);
	}
}