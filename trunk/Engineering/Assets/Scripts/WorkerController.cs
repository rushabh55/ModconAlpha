using UnityEngine;
using System.Collections;

public class WorkerController : MonoBehaviour {
    public ParticleSystem _partSystem = null;
    public GameObject _player = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 1)
        {
            //var objs = this.gameObject.GetComponentsInChildren(typeof(Renderer));
            //foreach ( Renderer renderer in objs )
            //{
            //    var color = renderer.material.color;
            //    color.a = 0;
            //    renderer.material.color = color;
            //}
            _partSystem.Emit(2500);
        }
	}
}
