using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

public class DebugPanel : MonoBehaviour {
    public Rect __BoxPosition;
    private static List<Object> _objCollection = new List<Object>();
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public static void AddText( UnityEngine.Object s )
    {
        _objCollection.Add(s);
    }

    void OnGUI()
    {
        GUI.Box(__BoxPosition, "");
        StringBuilder _stringBuilder = new StringBuilder();
        foreach ( UnityEngine.Object _obj in _objCollection)
        {
            _stringBuilder.Append(_obj.ToString() + "\n");
        }
        GUI.TextArea(__BoxPosition, _stringBuilder.ToString());
    }

}
