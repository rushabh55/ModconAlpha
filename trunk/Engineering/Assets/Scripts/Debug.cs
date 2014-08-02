using UnityEngine;
using System.Collections;

public class Debug : MonoBehaviour {
    GameObject[] _debugItems = null;
	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        if (_debugItems != null)
        {
            foreach (var _obj in _debugItems)
            {
                _obj.renderer.enabled = false;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
