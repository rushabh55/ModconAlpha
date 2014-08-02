using UnityEngine;
using System.Collections;

public class translate : MonoBehaviour {

    public SpringJoint _joint = null;
    public Transform _target = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var t = this.transform.rotation;
        this.transform.rotation.Set(0, 0, 0, 0);
        
        _joint.connectedAnchor = Vector3.MoveTowards(_joint.connectedAnchor, _target.position, Time.deltaTime * 1);

        this.transform.rotation = t;
    //    this.transform.Translate(new Vector3(1, 0, 0));
	}
}
