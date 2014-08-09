using UnityEngine;
using System.Collections;
using Assets.Scripts.Base;
using Assets.Scripts.Serializable;

public class WorkerController : MonoBehaviour , IExplode
{
    public ParticleSystem _partSystem = null;
    public GameObject _player = null;
    private TransformCollection _transform = new TransformCollection();
	// Use this for initialization
	void Start () {
        _transform.position = _player.transform.position;
        _transform.rotation = _player.transform.rotation;
        _transform.scale = _player.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if ( Input.touchCount > 0)
        {
            var delta = Input.acceleration;
            //_player.transform.Translate(-delta.y, 0, delta.x);
          //  DebugPanel.AddText(delta.ToString() + _player.transform.position.ToString());
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 1)
        {
            
        }
	}

    public void Explode()
    {
        _partSystem.Emit(2500);
        _player.renderer.active = false;
    }

    public void Respawn()
    {
        _player.renderer.active = true;
        _player.transform.position = _transform.position;
        _player.transform.rotation = _transform.rotation;
        _player.transform.localScale = _transform.scale;
    }
}
