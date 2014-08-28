using UnityEngine;
using System.Collections;

public class runtimeResourceLoader : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnGUI()
    {
        if ( GUI.Button(new Rect(Screen.width - 200, Screen.height - 100, 200, 100), "Load") )
        {
            var res = Resources.Load<Texture2D>("gear");
            if ( res != null )
            {
               // DebugPanel.AddText(res.name, true);
                Resources.UnloadUnusedAssets();
            }
        }
    }
}
