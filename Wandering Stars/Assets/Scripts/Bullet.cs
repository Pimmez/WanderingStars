using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	[SerializeField] private GameObject[] bullets;
	[SerializeField] private GameObject muzzle;
	[SerializeField] private float bulletForce = 800;

	private int currentBullet = 0;

	public AudioCueEvent bulletSound;
	public AudioSource source;

	private void Update()
	{
		ChangeBulletType();
		if(currentBullet == 0)
		{
			ShootRegularBullet();
		}
		else
		{
			MultiShot();
		}
	}

	private void ShootRegularBullet()
	{
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
		{
			GameObject bulletPrefab = Instantiate(bullets[0], muzzle.transform.position, Quaternion.identity);
			bulletPrefab.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletForce * Time.deltaTime, ForceMode2D.Impulse);
			bulletSound.Play(source);
		}
	}

	[SerializeField] private float fireRate = 3f;
	private float coneAngle;
	private float lastFired;
	public AudioCueEvent multiShotSound;
	public AudioSource multiShotSource;

	private void MultiShot()
	{
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
		{
			if (Time.time - lastFired > 1 / fireRate)
			{
				lastFired = Time.time;
				coneAngle = 60f;
				for (int i = 0; i < 5; i++)
				{
					Quaternion _shotRotation = gameObject.transform.rotation;
					_shotRotation *= Quaternion.Euler(0, 0, coneAngle);
					
					GameObject multiShotBullet = Instantiate(bullets[1], muzzle.transform.position, Quaternion.identity);

					multiShotBullet.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
					multiShotBullet.transform.rotation = _shotRotation;
					//multiShotSound.Play(multiShotSource);

					coneAngle = coneAngle - 30f;
				}
			}
		}
	}

	private void ChangeBulletType()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			// Add one to the curBullet variable when the player presses tab. 
			//This will allow you to fire the next bullet in the bullets Array
			currentBullet++;
			// If the curBullet is higher than the bullet array length set it back to 0
			if (currentBullet > bullets.Length - 1)
			{
				currentBullet = 0;
			}
		}
	}
}