using UnityEngine;
using System.Collections;

public class TapMouseRayCast : MonoBehaviour {
    public Camera _camera;
    public GameObject[] _objsToHide;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if( Input.touchCount > 0)
        {
            var pos = _camera.ScreenToWorldPoint(Input.touches[0].position);
            Debug.Log(pos);
            CheckForRayCollisions(pos);
        }

        if( Input.mousePresent )
        {
            if ( Input.GetMouseButton(0))
            {
                var pos = _camera.ScreenToWorldPoint(Input.mousePosition);
                //Debug.Log("start" + Input.mousePosition); 
                Debug.Log("end" + pos);
                CheckForRayCollisions(pos);
            }
        }
	}

    void CheckForRayCollisions(Vector3 pos)
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(pos, new Vector3(0, 0, -1));
        Debug.DrawLine(ray.origin,ray.direction, Color.green);
        if( Physics.Raycast(ray, out hit, 200 ))
        {
            if( hit.collider.name == "Play")
            {
                Debug.Log("play" + hit.collider.name);
            }
        }


        Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
       ;//hit exits now
       if (Physics.Raycast(ray1, out hit))
       {
           if (hit.collider.name == "Play")
           {
               Debug.Log("play" + hit.collider.name);
               hit.collider.renderer.material.color = Color.green;
           }
       }
       else
       {
           foreach (var t in _objsToHide)
           {
               t.renderer.material.color = Color.red;
           }
       }
    }

    void OnGUI()
    {

    }
}
