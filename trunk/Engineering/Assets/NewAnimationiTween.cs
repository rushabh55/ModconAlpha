using UnityEngine;
using System.Collections;

public class NewAnimationiTween 
    : MonoBehaviour {
    public Camera m_camera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPosition = new Vector3(_settingsMenu.transform.position.x,
                                          _camera.transform.position.y,
                                          _camera.transform.position.z);

        _camera.transform.position = Vector3.MoveTowards(
                                       _camera.transform.position,
                                       newPosition,
                                       Time.deltaTime * m_animSpeed
                                       );
	}
}
