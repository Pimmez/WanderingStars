using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : MonoBehaviour
{
	[SerializeField] private Transform muzzle = null;
	[SerializeField] private float fireRate = 3f;
	private float lastFired;


	public void ShootRegularBullet()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			if (Time.time - lastFired > 1 / fireRate)
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
}