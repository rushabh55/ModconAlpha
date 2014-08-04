using UnityEngine;
using System.Collections;
using Assets.Scripts.Base;

public class WorkerController : MonoBehaviour , IExplode
{
    public ParticleSystem _partSystem = null;
    public GameObject _player = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 1)
        {
            _partSystem.Emit(2500);
        }
	}

    public void Explode()
    {

    }
}
