using UnityEngine;
using System.Collections;

public class TapMouseRayCast : MonoBehaviour {
    public Camera _camera;
    public GameObject[] _objsToHide;
	// Use this for initialization
	void Start () 
    {
        Application.targetFrameRate = 3000;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if( Input.touchCount > 0)
        {
            CheckForRayCollisions(Input.touches[0].position);
        }
        else
        if( Input.mousePresent && Input.GetMouseButtonUp(0))
        {
            CheckForRayCollisions(Input.mousePosition);
        }
        else
        {
            foreach (var t in _objsToHide)
            {
                t.renderer.material.color = Color.black;
            }
        }

        if ( Input.GetKey(KeyCode.Backspace ) || Input.GetKey(KeyCode.Escape) )
        {
            Application.Quit();
        }
	}

    void CheckForRayCollisions(Vector3 pos)
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = _camera.ScreenPointToRay(pos);
        Debug.DrawLine(ray.origin,ray.direction, Color.green);
        if( Physics.Raycast(ray, out hit, 200 ))
        {
            if( hit.collider.name == "Play")
            {
                try
                {
                    Debug.Log(hit.collider.name);
                    hit.collider.renderer.material.color = Color.green;
                    Application.LoadLevelAdditive(1);
                    DebugPanel.AddText("loaded", true);
                }
                catch(System.Exception e)
                {
                    DebugPanel.AddText(e.Message, true);
                }
            }
        }
    }

    void OnGUI()
    {
        if ( GUI.Button ( new Rect (400, 100, 400, 100), "Load Level"))
        {
            Application.LoadLevelAdditive(1);
        }
    }
}
