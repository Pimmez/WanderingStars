using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SchipMovement : MonoBehaviour
{
	[SerializeField] private float rotationSpeed = 100f;
	[SerializeField] private float thrustForce = 40f;
	private Rigidbody2D rigid;

	/// <summary>
	/// PSEUDO CODE EngineSound
	/// 
	/// press w start accelerate sound while using input.getAxis
	/// max speed = looping engine sound
	/// release w = decrease engine sound
	/// 0 speed = engine running
	/// </summary>
	
	private void Awake()
	{
		rigid = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		KeyBoardControls();
	}

	private void KeyBoardControls()
	{
		float _horizontalMovenent = Input.GetAxis("Horizontal");
		float _verticalMovement = Input.GetAxis("Vertical");

		//Rotate the ship around
		transform.Rotate(0, 0, -_horizontalMovenent * rotationSpeed * Time.deltaTime);

		//Thrust the ship forward
		rigid.AddForce((transform.up * thrustForce * _verticalMovement) * Time.deltaTime);
	}
}