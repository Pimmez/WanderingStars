using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
	[SerializeField] private Transform muzzle = null;

    // Start is called before the first frame update
	private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
		ShootRegularBullet();
    }

	private void ShootRegularBullet()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameObject _bullet = ObjectPooler.SharedInstance.GetPooledObject();
			if (_bullet != null)
			{
				_bullet.transform.position = muzzle.position;
				_bullet.transform.rotation = transform.rotation;
				_bullet.SetActive(true);
			}
		}
	}
}
