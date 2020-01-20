using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AsteroidWaveSystem : MonoBehaviour
{
	public static Action<int> WavesEvent;
	public static Action<float> WaveTimerEvent;

	[SerializeField] private float waitTimeForInitialization = 1f;
	[SerializeField] private float waitTimeForNextWave = 10f;
	[SerializeField] private int increaseEachWave = 3;

	private int waveCounter = 0;
	private int asteroidSpawnAmount = 0;
	private Coroutine spawnWave;

	private void Start()
	{
		waveCounter = 1;
		spawnWave = StartCoroutine(SpawnWaves());
	}

	private void Update()
	{
		if (WavesEvent != null)
		{
			WavesEvent(waveCounter);
		}
		if (WaveTimerEvent != null)
		{
			WaveTimerEvent(waitTimeForNextWave);
		}
	}

	private IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(waitTimeForInitialization);

		asteroidSpawnAmount = waveCounter * increaseEachWave;

		while (true)
		{
			for (int i = 0; i < asteroidSpawnAmount; i++)
			{
				GameObject _asteroid = ObjectPooler.SharedInstance.GetPooledObject("Asteroid");
				if (_asteroid != null)
				{
					_asteroid.transform.position = new Vector3(UnityEngine.Random.Range(-5, 5), UnityEngine.Random.Range(-5, 5), 0);
					_asteroid.SetActive(true);
				}
			}
			yield return new WaitForSeconds(waitTimeForNextWave);
			waveCounter++;
		}
	}
}