using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroids : Asteroids
{
	public override void RotateAround()
	{
		base.RotateAround();
	}

	public override void FloatingAround()
	{
		base.FloatingAround();
	}

	public override void OnCollisionEnter2D(Collision2D other)
	{
		base.OnCollisionEnter2D(other);
		if (other.gameObject.tag == Tags.Player_Bullet)
		{
			other.gameObject.SetActive(false);
			gameObject.SetActive(false);
		}
	}
}