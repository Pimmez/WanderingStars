using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EuclideanTorus : MonoBehaviour
{
	[SerializeField] private float minX = -10F;
	[SerializeField] private float maxX = 10F;
	[SerializeField] private float minY = -7;
	[SerializeField] private float maxY = 7;

	private void Update()
	{
		// Teleport the game object to the other side of the screen
		if (transform.position.x > maxX)
		{

			transform.position = new Vector3(minX, transform.position.y, 0);
			if (gameObject.tag == "Player Bullet")
				{
					gameObject.SetActive(false);
				}
		}
		else if (transform.position.x < minX)
		{
			transform.position = new Vector3(maxX, transform.position.y, 0);
			if (gameObject.tag == "Player Bullet")
			{
				gameObject.SetActive(false);
			}
		}

		else if (transform.position.y > maxY)
		{
			transform.position = new Vector3(transform.position.x, minY, 0);
			if (gameObject.tag == "Player Bullet")
			{
				gameObject.SetActive(false);
			}
		}

		else if (transform.position.y < minY)
		{
			transform.position = new Vector3(transform.position.x, maxY, 0);
			if (gameObject.tag == "Player Bullet")
			{
				gameObject.SetActive(false);
			}
		}
	}
}