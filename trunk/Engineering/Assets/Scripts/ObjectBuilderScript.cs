using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System;
using System.Runtime.Serialization;

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
		Debug.Log( SerializableGameObjectWrapper.read() );		
		}

	public void DeserializeObject() {
		List<GameObject> obj = new List<GameObject>();
	}
}







public class SerializableGameObjectWrapper : System.Object
{
	public static System.Collections.Generic.List<SerializableGameObject> _obj = new System.Collections.Generic.List<SerializableGameObject>();

	public static void serialize(List<GameObject> list)
	{
		System.Xml.Serialization.XmlSerializer xmls =
			new System.Xml.Serialization.XmlSerializer(typeof (List<SerializableGameObject>));

		System.IO.FileStream fs = new System.IO.FileStream("C://Projects/xml", System.IO.FileMode.OpenOrCreate);
		foreach( var t in list)
		{
			SerializableGameObject s = new SerializableGameObject();
			s.transform = new SerializableTransform () { position = ObjConverter.convertFromNative( t.transform.position ),
				rotation = ObjConverter.convertFromNative( t.transform.rotation.eulerAngles ),
				scale = ObjConverter.convertFromNative ( t.transform.localScale ) };
			s.path = "afasf";
			s.tag = "afs";

			_obj.Add (s);
		}

		xmls.Serialize (fs, _obj);

		fs.Close(); }

	public static List<SerializableGameObject> read() {
		System.Xml.Serialization.XmlSerializer xmls =
			new System.Xml.Serialization.XmlSerializer(typeof (List<SerializableGameObject>));

		System.IO.FileStream fs = new System.IO.FileStream("C://Projects/xml", System.IO.FileMode.OpenOrCreate);
		List<SerializableGameObject> o = null;

		o = (List<SerializableGameObject>)xmls.Deserialize(fs);
		fs.Close();
		return o;
		}

	
	
	public class SerializableGameObject : System.Object
	{
		public string path;
		public SerializableTransform transform;
		public string tag;
		
		public SerializableGameObject()
		{
			transform = new SerializableTransform();
			transform.position = ObjConverter.convertFromNative(new System.Random().Next(1, 100), new System.Random().Next(1, 100), new System.Random().Next(1, 100));
			
			transform.rotation = ObjConverter.convertFromNative(new System.Random().Next(1, 100), new System.Random().Next(1, 100), new System.Random().Next(1, 100));
			transform.scale = ObjConverter.convertFromNative(new System.Random().Next(1, 100), new System.Random().Next(1, 100), new System.Random().Next(1, 100));            
			
		}
	}

   }


   public class SerializableGameObject : System.Object
   {
      public string path;
     public SerializableTransform transform;
      public string tag;

      public SerializableGameObject()
      {
         transform = new SerializableTransform();
         transform.position = ObjConverter.convertFromNative(new System.Random().Next(1, 100), new System.Random().Next(1, 100), new System.Random().Next(1, 100));

         transform.rotation = ObjConverter.convertFromNative(new System.Random().Next(1, 100), new System.Random().Next(1, 100), new System.Random().Next(1, 100));
         transform.scale = ObjConverter.convertFromNative(new System.Random().Next(1, 100), new System.Random().Next(1, 100), new System.Random().Next(1, 100));            

      }
   }


   public struct SerializableTransform
   {
      public SerializableVector position, rotation, scale;
   }


   public struct SerializableVector
   {
      public float x, y, z;
   }


   public class ObjConverter
   {
      public static SerializableVector convertFromNative(float x, float y, float z)
      {
         SerializableVector s = new SerializableVector();
         s.x = x;
         s.y = y;
         s.z = z;
         return s;
      }

		public static SerializableVector convertFromNative(Vector3 vec)
		{
			SerializableVector s = new SerializableVector();
			s.x = vec.x;
			s.y = vec.y;
			s.z = vec.z;
			return s;
		}

   }