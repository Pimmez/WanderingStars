using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Asteroid : MonoBehaviour
{
	public static Action<int> AsteroidScoreEvent;

	[SerializeField] private int AsteroidscoreAmount = 1000;
	[SerializeField] private float minTurningSpeed = 40f;
	[SerializeField] private float maxTurningSpeed = 200f;

	[SerializeField] private float minSpeed = -40;
	[SerializeField] private float maxSpeed = 40;

	[SerializeField] private GameObject smallAsteroid = null;

	private void Start()
	{
		Floating();
	}	

	private void Update()
	{
		RotateAround();
	}

	public virtual void Floating()
	{
		Rigidbody2D _rigid = GetComponent<Rigidbody2D>();
		Vector2 randomPosition = new Vector2((float)UnityEngine.Random.Range(minSpeed, maxSpeed), (float)UnityEngine.Random.Range(minSpeed, maxSpeed));
		_rigid.AddForce(randomPosition * Time.deltaTime, ForceMode2D.Impulse);
	}

	public virtual void RotateAround()
	{
		Vector3 _turningSpeed = new Vector3(0, 0, UnityEngine.Random.Range(minTurningSpeed, maxTurningSpeed));
		transform.Rotate(_turningSpeed * Time.deltaTime);
	}

	public virtual void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == Tags.RegularBullet)
		{
			GameObject _object = (GameObject)Instantiate(smallAsteroid);
			_object.transform.position = transform.position;

			GameObject _object2 = (GameObject)Instantiate(smallAsteroid);
			_object2.transform.position = transform.position;

			if(AsteroidScoreEvent != null)
			{
				AsteroidScoreEvent(AsteroidscoreAmount);
			}

			Destroy(collision.gameObject);
			gameObject.SetActive(false);
		}
	}
}