using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

public class DebugPanel : MonoBehaviour {
    public Rect __BoxPosition;
    private static StringBuilder _objCollection = new StringBuilder();
	
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public static void AddText( string s )
    {
        _objCollection = null;
        _objCollection = new StringBuilder();
        _objCollection.Append(s);
    }

    void OnGUI()
    {
        GUI.Box(__BoxPosition, "");
        GUI.skin.textArea.fontSize = 50;
        GUI.TextArea(__BoxPosition, _objCollection.ToString());
    }

}
