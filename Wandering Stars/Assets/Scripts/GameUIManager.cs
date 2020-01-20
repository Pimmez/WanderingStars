using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI textWaves;
	[SerializeField] private TextMeshProUGUI textLives;
	[SerializeField] private TextMeshProUGUI textWaveTimer;
	[SerializeField] private TextMeshProUGUI textScore;

	private bool isPlayerDead = false;

	private void Start()
    {
		textWaves.text = "Waves: " + 0;
    }

	private void UpdateWaves(int _waves)
	{
		if(!isPlayerDead)
		{
			textWaves.text = "Waves: " + _waves;
		}
		else
		{
			return;
		}
	}

	private void UpdateWaveTimer(float _waveTimer)
	{
		if (!isPlayerDead)
		{
			textWaveTimer.text = "Next Wave: " + _waveTimer;
		}
		else
		{
			return;
		}
	}

	private void OnEnable()
	{
		AsteroidWaveSystem.WavesEvent += UpdateWaves;
		AsteroidWaveSystem.WaveTimerEvent += UpdateWaveTimer;
	}

	private void OnDisable()
	{
		AsteroidWaveSystem.WavesEvent -= UpdateWaves;
		AsteroidWaveSystem.WaveTimerEvent -= UpdateWaveTimer;
	}
}