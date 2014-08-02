using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using Assets;
using System.Collections.Generic;
using System.IO;
public class Loader : MonoBehaviour {

    private XmlSerializer xmlS = new XmlSerializer(typeof(List<GameObject>));
    static List<Object> __list = new List<Object>();
    public Texture __bgTex;
    public GameObject __bgObj;

    public void AddData ( GameObject obj )
    {
        __bgObj.transform.localScale = new Vector3(Screen.height / Vector3.Distance(Camera.main.transform.position, __bgObj.transform.position), Screen.width / Vector3.Distance(Camera.main.transform.position, __bgObj.transform.position), 1);
        Camera.main.transform.LookAt(__bgObj.transform);
        UnityEngine.Debug.Log("Added ");
        UnityEngine.Debug.Log(obj);
        __list.Add((Object)obj);
    }
	// Use this for initialization
	void Start () {
        var t = GameObject.FindGameObjectsWithTag("Untagged"); 
        if ( t.Length == 0 )
        {
            UnityEngine.Debug.Log("0");
        }
        object[] allObjects = FindObjectsOfTypeAll(typeof(GameObject));
        foreach (object thisObject in allObjects)
            if (((GameObject)thisObject).activeInHierarchy)
            {
                print(thisObject + " is an active object");
                AddData((GameObject)thisObject);
            }
        Serialize();
	}

    private void Serialize()
    {
       // FileStream fs = new FileStream("c:\\wasd.wasd", FileMode.OpenOrCreate);

        try
        {
        //    xmlS.Serialize(fs, __list);

        //    fs.Close();
        }
        catch (System.Exception e)
        {
          //  UnityEngine.Debug.Log(e.Message);
          //  fs.Close();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if( Input.touchCount > 0 )
	    __bgObj.transform.Translate(new Vector3(Input.acceleration.x, 0, -Input.acceleration.z ));
	}
}
