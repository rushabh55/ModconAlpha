using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

public class DebugPanel : MonoBehaviour {
    public Rect __BoxPosition;
    private static StringBuilder _objCollection = new StringBuilder();
    public GameObject _player;
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public static void AddText( string s, bool erase = false )
    {        
        if ( erase )
        {
            _objCollection = null;
            _objCollection = new StringBuilder(1500);
        }
        _objCollection.Append(s + "\n");
    }

    void OnGUI()
    {
        GUI.Box(__BoxPosition, "");
        GUI.skin.textArea.fontSize = 30;
        GUI.TextArea(__BoxPosition, _objCollection.ToString());
        GUI.skin.label.fontSize = 30;
        GUI.Label(new Rect(__BoxPosition.x + __BoxPosition.width, __BoxPosition.y, 250, 75), "FPS : " + (1f / Time.deltaTime).ToString());
        GUI.Label(new Rect(__BoxPosition.x, __BoxPosition.y + __BoxPosition.height, 250, 75), "playerPos : " + _player.transform.position);

    }

}
