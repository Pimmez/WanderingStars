using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class SmallAsteroid : Asteroid
{
	public static Action<int> smallAsteroidScoreEvent;


	[SerializeField] private int smallAsteroidScoreAmount = 500;


	public override void RotateAround()
	{
		base.RotateAround();
	}

	public override void Floating()
	{
		base.Floating();
	}

	public override void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == Tags.RegularBullet)
		{
			if (smallAsteroidScoreEvent != null)
			{
				smallAsteroidScoreEvent(smallAsteroidScoreAmount);
			}

			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}