using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
	public Transform target;

	public float missileSpeed = 20f;
	public float rotateSpeed = 50f;

	private Rigidbody2D rigid;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		GameObject _asteroid = ObjectPooler.SharedInstance.GetPooledObject(Tags.Asteroid);

		target = _asteroid.transform;

		Vector2 _direction = (Vector2)target.position - rigid.position;

		_direction.Normalize();

		float _rotateAmount = Vector3.Cross(_direction, transform.up).z;

		rigid.angularVelocity = -_rotateAmount * rotateSpeed;

		rigid.velocity = transform.up * missileSpeed;
	}
}