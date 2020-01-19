using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
	[SerializeField] private Transform muzzle = null;
	[SerializeField] private float fireRate = 3f;
	private float lastFired;

    // Update is called once per frame
    private void Update()
    {
		ShootRegularBullet();
    }

	private void ShootRegularBullet()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			if(Time.time - lastFired > 1 / fireRate)
			{
				lastFired = Time.time;

				GameObject _bullet = ObjectPooler.SharedInstance.GetPooledObject("Player Bullet");
				if (_bullet != null)
				{
					_bullet.transform.position = muzzle.position;
					_bullet.transform.rotation = transform.rotation;
					_bullet.SetActive(true);
				}
			}
		}
	}
}
