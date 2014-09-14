using UnityEngine;
using System.Collections;

public class AdjustPositions : MonoBehaviour
{
    public GameObject pole1, pole2, _start, _target;
    public GameObject pole12, pole22, _start2, _target2;


    public GameObject _player;
    public GameObject _player2;

    public GameObject _psuedoWorker;

    public static bool isDoubleEnabled;

	// Use this for initialization
	void Start () 
    {
        isDoubleEnabled = false;
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
        pos.y = (float)((int)pole1.renderer.bounds.size.y >> 1) + ((int)((BoxCollider)_psuedoWorker.collider).size.y << 3);
        _start.transform.position = pos;

        _target.transform.position = pole2.transform.position;
        pos = _target.transform.position;
        var t = ((int)((BoxCollider)_psuedoWorker.collider).size.y << 1);
        pos.y = (float)((int)pole2.renderer.bounds.size.y >> 1) + ((int)((BoxCollider)_psuedoWorker.collider).size.y << 3);
        pos.z = pole2.transform.position.z;
        _target.transform.position = pos;
        try
        {
            _player.transform.position
                = _start.transform.position;
        }
        catch (System.Exception e) { }
        if (_player2.renderer.isVisible)
        {
            _start2.transform.position = pole12.transform.position;
            pos = _start2.transform.position;
            pos.y = (float)((int)pole12.renderer.bounds.size.y >> 1) + ((int)((BoxCollider)_psuedoWorker.collider).size.y << 3);
            _start2.transform.position = pos;

            _target2.transform.position = pole22.transform.position;
            pos = _target2.transform.position;
            t = ((int)((BoxCollider)_psuedoWorker.collider).size.y << 1);
            pos.y = (float)((int)pole22.renderer.bounds.size.y >> 1) + ((int)((BoxCollider)_psuedoWorker.collider).size.y << 3);

            _target2.transform.position = pos;
            _player2.transform.position = _start2.transform.position;

            isDoubleEnabled = true;
        }
    }
	// Update is called once per frame
	void Update () 
    {
	
	}
}
