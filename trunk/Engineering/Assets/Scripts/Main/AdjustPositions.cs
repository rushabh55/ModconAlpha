using UnityEngine;
using System.Collections;

public class AdjustPositions : MonoBehaviour
{
    public GameObject pole1, pole2, _start, _target;
    public GameObject _player;

	// Use this for initialization
	void Start () 
    {
        Reposition();
        Application.targetFrameRate = 10000;

	}

    void Awake()
    {
        Reposition();
    }
	
    public void Reposition()
    {
        _start.transform.position = pole1.transform.position;
        var pos = _start.transform.position;
        pos.y = (float)((int)pole1.renderer.bounds.size.y >> 1) + ((int)((BoxCollider)_player.collider).size.y <<3 );
        _start.transform.position = pos;

        _target.transform.position = pole2.transform.position;
        pos = _target.transform.position;
        var t = ((int)((BoxCollider)_player.collider).size.y << 1);
        pos.y = (float)((int)pole2.renderer.bounds.size.y >> 1) + ((int)((BoxCollider)_player.collider).size.y <<3);
        pos.z = pole2.transform.position.z;
        _target.transform.position = pos;
        _player.transform.position
             = _start.transform.position;
    }
	// Update is called once per frame
	void Update () 
    {
	
	}
}
