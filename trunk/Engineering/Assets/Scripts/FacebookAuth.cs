using UnityEngine;
using System.Collections;

public class FacebookAuth : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //FB.Init(onInitComplete, onHideComplete);
	}

    private void onHideComplete(bool isUnityShown)
    {

    }

    private void onInitComplete()
    {
        DebugPanel.AddText("Init Complete ");

        FB.Login("user_about_me, user_activities, user_birthday, public_profile, user_friends, email", onLoginCallback);
    }

    private void onLoginCallback(FBResult result)
    {
        DebugPanel.AddText("Login InComplete ");
        if (result.Error != null)
        {
            DebugPanel.AddText("Login Complete ");

            Debug.Log(result.Text);
        }
    }

    public void OnGUI()
    {
        if ( GUI.Button ( new Rect ( 500, 250, 100, 40), "FB LOGIN"))
        FB.Init(onInitComplete, onHideComplete);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
