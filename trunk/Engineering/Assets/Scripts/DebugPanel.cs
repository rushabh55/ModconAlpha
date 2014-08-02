using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

public class DebugPanel : MonoBehaviour {
    public Rect __BoxPosition;
    private static StringBuilder _objCollection = new StringBuilder();
	// Use this for initialization
	void Start () 
    {
        FB.Init(onInitComplete, onHideunity);
        _objCollection.Append("yo");
	}

    private void onHideunity(bool isUnityShown)
    {
        FB.Login("email,publish_actions", loginComplete);
    }

    private void loginComplete(FBResult result)
    {
        FB.Login("email,publish_actions", loginComplete);
        if ( result.Error != null )
        {
            FB.Login("", loginComplete);
           // UnityEngine.Debug.Log("Logged in ");
        }
    }

    private void onInitComplete()
    {
        if (! FB.IsLoggedIn )
        FB.Login("email,publish_actions", loginComplete);
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public static void AddText( string s )
    {
        _objCollection.Append(s);
    }

    void OnGUI()
    {
        GUI.Box(__BoxPosition, "");
        GUI.skin.textArea.fontSize = 50;
        GUI.TextArea(__BoxPosition, _objCollection.ToString());
    }

}
