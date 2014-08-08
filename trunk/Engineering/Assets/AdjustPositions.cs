using UnityEngine;
using System.Collections;

public class AdjustPositions : MonoBehaviour
{
    public GameObject pole1, pole2, _start, _target;
	// Use this for initialization
	void Start () 
    {
        Reposition();
	}

    void Awake()
    {
        Reposition();
    }
	
    public void Reposition()
    {
        _start.transform.position = pole1.transform.position;
        var pos = _start.transform.position;
        pos.z += (float)pole1.renderer.bounds.size.y / 2 * (float)pole1.transform.localScale.y;
        _start.transform.position = pos;

        _target.transform.position = pole2.transform.position;
        pos = _target.transform.position;
        pos.z += (float)pole2.renderer.bounds.size.y / 2 * (float)pole2.transform.localScale.y;
        _target.transform.position = pos;
    }
	// Update is called once per frame
	void Update () 
    {
	
	}
}
