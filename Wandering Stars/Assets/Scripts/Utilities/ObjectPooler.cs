using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
	public GameObject objectToPool = null;
	[SerializeField] private List<GameObject> pooledObjects = new List<GameObject>();
	[SerializeField] private int amountToPool = 0;
	[SerializeField] private bool isPoolExpanding = true;

	#region Singleton
	public static ObjectPooler SharedInstance;

	void Awake()
	{
		SharedInstance = this;
	}
	#endregion

	private void Start()
	{
		for (int i = 0; i < amountToPool; i++)
		{
			GameObject _object = (GameObject)Instantiate(objectToPool);
			_object.SetActive(false);
			pooledObjects.Add(_object);
		}
	}

	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++)
		{
			if(!pooledObjects[i].activeInHierarchy)
			{
				return pooledObjects[i];
			}
		}
		if (isPoolExpanding)
		{
			GameObject _object = (GameObject)Instantiate(objectToPool);
			_object.SetActive(false);
			pooledObjects.Add(_object);
			return _object;
		}
		else
		{
			return null;
		}
	}
}