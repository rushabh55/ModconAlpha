using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
    public GameObject __objectToControl;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if ( Input.touchCount > 0 )
        {
            Vector3 delta = Input.acceleration;
            __objectToControl.transform.Translate(new Vector3(delta.x * 0.1f, 0, delta.z * 0.1f));
            DebugPanel.AddText( delta.ToString() );
        }
	}
}
