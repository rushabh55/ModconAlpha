using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if ( Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            Application.LoadLevel(0);
        }
	}
}
