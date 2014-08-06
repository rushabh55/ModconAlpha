using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
    public GameObject __objectToControl;
    public GameObject _player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if ( Input.touchCount > 0 )
        {
            var delta = Input.acceleration;
            __objectToControl.transform.Translate(delta.x * 0.45f, 0, delta.y * 0.45f);
            DebugPanel.AddText(delta.ToString() + __objectToControl.transform.position.ToString());

            if (Physics.Raycast(__objectToControl.transform.position, __objectToControl.transform.TransformDirection(Vector3.forward), 1000))
            {
                DebugPanel.AddText("RayHit", true);
            }

            Rect rect = new Rect(__objectToControl.transform.position.x, __objectToControl.transform.position.z,
                                __objectToControl.transform.localScale.x, __objectToControl.transform.localScale.z);
            if ( rect.Contains(new Vector2(_player.transform.position.x, _player.transform.position.z)) )
            {
                DebugPanel.AddText("Collided", true);
            }
        }
	}
}
