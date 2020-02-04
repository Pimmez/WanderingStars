using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
	[SerializeField] private int maxLives = 3;
	private int lives = 0;
	//[SerializeField] private Transform muzzle = null;
	//[SerializeField] private float fireRate = 3f;
	//private float lastFired;

	private Animator anim;

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}

	private void Start()
	{
		lives = maxLives;
	}

	// Update is called once per frame
	private void Update()
    {
		if(lives <= 0)
		{
			Destroy(gameObject);
		}


		//ShootRegularBullet();


		/*
		if(isMissileActive)
		{
			ShootHomingMissiles();
		}
		*/
    }

	/*
	private void ShootRegularBullet()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			if(Time.time - lastFired > 1 / fireRate)
			{
				lastFired = Time.time;

				GameObject _bullet = ObjectPooler.SharedInstance.GetPooledObject(Tags.RegularBullet);
				if (_bullet != null)
				{
					_bullet.transform.position = muzzle.position;
					_bullet.transform.rotation = transform.rotation;
					_bullet.SetActive(true);
				}
			}
		}
	}
	/*

	private void RespawingShip()
	{

		anim.SetBool("isRespawning", true);
		//AnimatorPlayer.instance.SetAnimationBool(anim, "isRespawning", true);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == Tags.Asteroid)
		{
			lives--;
			RespawingShip();
		}
		else
		{
			AnimatorPlayer.instance.SetAnimationBool(anim, "isRespawning", false);
		}
	}

	/*
	private void ShootHomingMissiles()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			if (Time.time - lastFired > 1 / fireRate)
			{
				lastFired = Time.time;

				GameObject _missile = ObjectPooler.SharedInstance.GetPooledObject(Tags.HomingMissile);
				if (_missile != null)
				{
					_missile.transform.position = muzzle.position;
					_missile.transform.rotation = transform.rotation;
					_missile.SetActive(true);
				}
			}
		}
	}
	*/
}