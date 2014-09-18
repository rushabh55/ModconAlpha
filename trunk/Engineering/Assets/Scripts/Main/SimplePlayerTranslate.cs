using UnityEngine;
using System.Collections;
using Assets.Scripts.Base;
using MAIN_SETTINGS;

public class SimplePlayerTranslate : MonoBehaviour , ILevelObject
{
    public GameObject _player;
    public GameObject _player2;

    public GameObject start;
    public GameObject end;

    public GameObject start2;
    public GameObject end2;

    static int SPEED = 20;
    public Camera camera;
    public ParticleSystem _explosionParticleSystem;
    public AdjustPositions m_sAdjustPositions;

    public GameObject __bgObj;

    public enum InputType
    {
        Mouse,
        Touch,
        Accelerometer
    };


    public InputType _inputType;
    public GUITexture crossHair;

    public void InitializePosition()
    {
        m_sAdjustPositions.Reposition();
        _player.collider.renderer.active = true;
    }

    public void Explode()
    {
        _explosionParticleSystem.Emit(250);
    }
    public void LevelEnd()
    {

    }
    
	// Update is called once per frame
	void Update () 
    {
        _player.transform.position = Vector3.MoveTowards(_player.transform.position, end.transform.position, Time.deltaTime * Settings.m_currentLevelSpeed);
        if (AdjustPositions.isDoubleEnabled)
        {
            if (_player2 != null)
            {
                try
                {
                    _player2.transform.position = Vector3.MoveTowards(_player2.transform.position, end2.transform.position, Time.deltaTime * Settings.m_currentLevelSpeed);
                }
                catch (System.Exception e) { }
            }
        }
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
        CheckForAccInput();
    }

    private void CheckForAccInput()
    {
        __bgObj.transform.Translate(new Vector3(Input.acceleration.x, 0, -Input.acceleration.z));
    }

    private void CheckForVectorCollision()
    {
        var pos = crossHair.pixelInset.center;
        Ray ray = camera.ScreenPointToRay(pos);
        RaycastHit hit = new RaycastHit();
        if ( Physics.Raycast(ray, out hit) )
        {
            if (hit.collider.name == "Player")
            {
                Explode();
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
