using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System;
using System.Runtime.Serialization;
using Assets.Scripts.Serializable;

public class ObjectBuilderScript : MonoBehaviour
{
	public GameObject obj;
	public Vector3 spawnPoint;

	public void BuildObject()
	{
		Instantiate(obj, spawnPoint, Quaternion.identity);
	}


	public void SerializeObject()
	{
		List<GameObject> obj = new List<GameObject>();
		object[] allObjects = FindObjectsOfTypeAll(typeof(GameObject));
		foreach(object thisObject in allObjects)
		{
			if (((GameObject) thisObject).activeInHierarchy)
			{
				obj.Add ((GameObject) thisObject);
				Debug.Log (" Printing " + thisObject);
			}
		}
		SerializableGameObjectWrapper.serialize(obj);
		}

	public void DeserializeObject() {
		List<GameObject> obj = new List<GameObject>();
	}
}






