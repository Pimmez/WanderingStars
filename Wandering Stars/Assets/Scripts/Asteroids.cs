using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Virtual means that it can be overriden by another inheranted class.
//Overriden means that the class will use the same method but not the same code.
//Sealed means it can't be inheranted by other classes.


public class Asteroids : MonoBehaviour
{
	[SerializeField] private float minTurningSpeed = 40f;
	[SerializeField] private float maxTurningSpeed = 200f;

	private void Start()
	{
		FloatingAround();
	}

	private void FixedUpdate()
	{
		RotateAround();
	}

	public virtual void RotateAround()
	{
		Vector3 _turningSpeed = new Vector3(0, 0, UnityEngine.Random.Range(minTurningSpeed, maxTurningSpeed));
		transform.Rotate(_turningSpeed * Time.deltaTime);
	}

	public virtual void FloatingAround()
	{
		Rigidbody2D _rigid = GetComponent<Rigidbody2D>();
		Vector2 randomPosition = new Vector2((float)UnityEngine.Random.Range(-30f, 30f), (float)UnityEngine.Random.Range(-30f, 30f));
		_rigid.AddForce(randomPosition * Time.deltaTime, ForceMode2D.Impulse);
	}

	public virtual void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == Tags.Player)
		{
			Destroy(other.gameObject);
		}
	}
}
