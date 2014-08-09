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

	}

    void Awake()
    {
        Reposition();
    }
	
    public void Reposition()
    {
        _start.transform.position = pole1.transform.position;
        var pos = _start.transform.position;
        pos.y += (float)pole1.renderer.bounds.size.y / 2 - ((int)((BoxCollider)_player.collider).size.y << 1);
        _start.transform.position = pos;

        _target.transform.position = pole2.transform.position;
        pos = _target.transform.position;
        pos.y += (float)pole2.renderer.bounds.size.y / 2 - ((int)((BoxCollider)_player.collider).size.y << 1);
        _target.transform.position = pos;
    }
	// Update is called once per frame
	void Update () 
    {
	
	}
}
