using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Asteroid : Asteroids
{
	[SerializeField] private GameObject smallAsteroid = null;

	public override void RotateAround()
	{
		base.RotateAround();
	}

	public override void FloatingAround()
	{
	}

	public override void OnCollisionEnter2D(Collision2D other)
	{
		base.OnCollisionEnter2D(other);
		if (other.gameObject.tag == Tags.Player_Bullet)
		{
			other.gameObject.SetActive(false);

			GameObject _object = (GameObject)Instantiate(smallAsteroid);
			_object.transform.position = transform.position;

			GameObject _object2 = (GameObject)Instantiate(smallAsteroid);
			_object2.transform.position = transform.position;
			Destroy(gameObject);
		}
	}
}