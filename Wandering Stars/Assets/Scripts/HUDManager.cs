using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
	[SerializeField] private TMP_Text showLives = null;

	[SerializeField] private TMP_Text showScore = null;

	[SerializeField] private TMP_Text showWave = null;

	[SerializeField] private TMP_Text showHighScore = null;

	private int score;

	private void HUDLives(int _lives)
	{
		showLives.text = "Lives: " + _lives;
	}

	private void HUDScore(int _score)
	{
		score += _score;
		showScore.text = "Score: " + score;
	}

	private void HUDWave(int _wave)
	{
		showWave.text = "Wave: " + _wave;
	}

	private void OnEnable()
	{
		PlayerHealth.SendLivesEvent += HUDLives;
		Asteroid.AsteroidScoreEvent += HUDScore;
		SmallAsteroid.smallAsteroidScoreEvent += HUDScore;
		AsteroidWaveSystem.WaveEvent += HUDWave;
	}

	private void OnDisable()
	{
		PlayerHealth.SendLivesEvent -= HUDLives;
		Asteroid.AsteroidScoreEvent -= HUDScore;
		SmallAsteroid.smallAsteroidScoreEvent -= HUDScore;
		AsteroidWaveSystem.WaveEvent -= HUDWave;
	}
}