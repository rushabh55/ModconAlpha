using UnityEngine;
using System.Collections;

public class translate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(new Vector3(1, 0, 0));
	}
}
