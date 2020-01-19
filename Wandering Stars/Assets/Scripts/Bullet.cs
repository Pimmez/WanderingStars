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
		rigid.AddForce(transform.up * bulletForce * Time.deltaTime, ForceMode2D.Impulse);
	}
}