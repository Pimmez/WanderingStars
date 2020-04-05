using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
	public static Action<int> SendLivesEvent;

	private int lives = 0;
	private int maxLives = 3;

	private void Start()
	{
		lives = maxLives;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == Tags.Asteroid)
		{
			if(lives > 1)
			{
				lives--;
				gameObject.transform.position = new Vector3(0, 0, 0);
				//PLAY ANIMATION

				if(SendLivesEvent != null)
				{
					SendLivesEvent(lives);
				}
			}
			else if(lives == 1)
			{
				Destroy(gameObject);
				GameManager.instance.GameOver();
			}
		}
	}
}
