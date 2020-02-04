using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
	public static LoadingScreen instance;

	[SerializeField] private Image loadingProgressBar; 
	[SerializeField] private GameObject loadingBarHolder;
	[SerializeField] private TextMeshProUGUI percentageText;

	private void Awake()
	{
		if(instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public void LoadLevelASync(string _levelName)
	{
		StartCoroutine(LoadSceneASynchronously(_levelName));
	}

	IEnumerator LoadSceneASynchronously(string _levelName)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(_levelName);
		loadingBarHolder.SetActive(true);

		while(!operation.isDone)
		{
			float progression = operation.progress / 0.9f;

			loadingProgressBar.fillAmount = progression;
			percentageText.text = progression * 100f + "%";

			if (progression >= 1f)
			{
				loadingBarHolder.SetActive(false);
			}

		}

		yield return new WaitForSeconds(2f);

	}
}