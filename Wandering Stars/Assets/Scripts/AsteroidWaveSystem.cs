using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AsteroidWaveSystem : MonoBehaviour
{
	public static Action<int> WaveEvent;

	[SerializeField] private float waitTimeForNextWave = 10f;
	[SerializeField] private int increaseEachWave = 3;


	[SerializeField] private Transform[] spawnPoints;

	private int waveCounter = 0;
	private int asteroidSpawnAmount = 0;
	private Coroutine spawnWave;

	private void Start()
	{
		waveCounter = 1;

		if (WaveEvent != null)
		{
			WaveEvent(waveCounter);
		}

		spawnWave = StartCoroutine(SpawnWaves());
	}

	private IEnumerator SpawnWaves()
	{
		asteroidSpawnAmount = waveCounter * increaseEachWave;

		while (true)
		{
			for (int i = 0; i < asteroidSpawnAmount; i++)
			{
				GameObject _asteroid = ObjectPooler.SharedInstance.GetPooledObject("Asteroid");
				int spawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
				Vector3 changeScale = new Vector3(UnityEngine.Random.Range(1, 3), UnityEngine.Random.Range(1, 3), 1);

				if (_asteroid != null)
				{
					_asteroid.transform.localScale = changeScale;
					_asteroid.transform.position = spawnPoints[spawnPointIndex].position;
					_asteroid.SetActive(true);
					
				}
			}

			yield return new WaitForSeconds(waitTimeForNextWave);

			waveCounter++;

			if(WaveEvent != null)
			{
				WaveEvent(waveCounter);
			}

		}
	}
}