using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Rigidbody2D rigid;
	[SerializeField] private float bulletForce = 5f;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		rigid.velocity = transform.up * 1000 * Time.deltaTime;
	}
}