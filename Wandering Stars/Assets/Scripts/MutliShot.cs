using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutliShot : MonoBehaviour
{
	[SerializeField] private float fireRate = 3f;
	private float coneAngle;
	private float lastFired;

	private void Update()
	{
		MultiShootCone();
	}

	public void MultiShootCone()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			if (Time.time - lastFired > 1 / fireRate)
			{
				lastFired = Time.time;
				coneAngle = 60f;
				for (int i = 0; i < 5; i++)
				{


				Quaternion _shotRotation = gameObject.transform.rotation;
				_shotRotation *= Quaternion.Euler(0, 0, coneAngle);

				GameObject _bulletSpread = ObjectPooler.SharedInstance.GetPooledObject(Tags.RegularBullet);

				if (_bulletSpread != null)
				{
					_bulletSpread.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
					_bulletSpread.transform.rotation = _shotRotation;
					_bulletSpread.SetActive(true);
				}
				coneAngle = coneAngle - 30f;
				}
			}
		}
	}
}