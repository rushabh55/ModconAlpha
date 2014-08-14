using UnityEngine;
using System.Collections;

public class SimplePlayerTranslate : MonoBehaviour 
{
    public GameObject _player;
    public GameObject start;
    public GameObject end;
    static int SPEED = 20;
    public Camera camera;
    public ParticleSystem _explosionParticleSystem;
    public enum InputType
    {
        Mouse,
        Touch,
        Accelerometer
    };


    public InputType _inputType;
    public GUITexture crossHair;
    
	// Update is called once per frame
	void Update () 
    {
        _player.transform.position = Vector3.MoveTowards(_player.transform.position, end.transform.position, Time.deltaTime * SPEED);        
	}

    void FixedUpdate()
    {
        Input.simulateMouseWithTouches = true;
        if (Input.mousePresent && Input.GetMouseButton(0))
        {
            MouseUpdate();
        }

        if ( Input.multiTouchEnabled )
        {
            TouchUpdate();
        }

        CheckForCollision();
        CheckForVectorCollision();
    }

    private void CheckForVectorCollision()
    {
        var pos = crossHair.pixelInset.center;
        Ray ray = camera.ScreenPointToRay(pos);
        RaycastHit hit = new RaycastHit();
        if ( Physics.Raycast(ray, out hit) )
        {
            if (hit.collider.name == "Worker")
            {
                _explosionParticleSystem.Emit(250);
            }
        }
    }

    private void CheckForCollision()
    {
        Rect r = crossHair.pixelInset;
        var playerPosition = _player.transform.position;
        playerPosition.x *= -1;
        var posToCheck = new Vector2(playerPosition.x, playerPosition.y);
       
        if ( r.Contains ( posToCheck ))
        {

        }
    }

    void MouseUpdate()
    {
        var pos = Input.mousePosition;
        crossHair.pixelInset = new Rect(pos.x, pos.y, 10, 10);
    }

    void TouchUpdate()
    {
        try
        {
            var pos = Input.touches[0].position;
            crossHair.pixelInset = new Rect(pos.x, pos.y, crossHair.pixelInset.width, crossHair.pixelInset.height);
        }
        catch(System.Exception e)
        {
            if (e.GetType() != typeof(System.IndexOutOfRangeException))
            {
                Debug.Log(e);
            }
        }
    }
}
