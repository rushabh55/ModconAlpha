
using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour 
{
    private const short WIDTH = 100;
    public GameObject __objectToControl;
    public GameObject _player;
    public Camera _camera;
    private Rect _guiPos;
    private GameObject _target;

	// Use this for initialization
	void Start () 
    {
        //_camera.transform.LookAt(_player.transform);
	}

    public void GetTarget()
    {
        _target = GameObject.Find("Globals").GetComponent<AdjustPositions>()._target;
    }

    void Awake()
    {
        GameObject.Find("Globals").GetComponent<AdjustPositions>().Reposition();
        Application.targetFrameRate = 300;
#if UNITY_ANDROID
        Debug.Log("android");
#endif
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        Debug.Log("pc");
#endif
    }
	
	// Update is called once per frame
	void Update () {
	   // if ( Input.touchCount > 0 )
        {

            var pos = __objectToControl.GetComponent<GUITexture>().pixelInset.position;
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
            var delta = new Vector2(Input.mousePosition.x - pos.x - 500 - 183, -500 + Input.mousePosition.y - pos.y);
            pos += delta;
            pos.x = Mathf.Clamp(pos.x, -Screen.width / 2, Screen.width / 2 - WIDTH / 2);
            pos.y = Mathf.Clamp(pos.y, -Screen.height / 2, Screen.height / 2 - WIDTH / 2);

            __objectToControl.GetComponent<GUITexture>().pixelInset = new Rect(pos.x, pos.y, WIDTH, WIDTH);
            _guiPos = __objectToControl.GetComponent<GUITexture>().pixelInset;
#endif
//#if UNITY_ANDROID
            AccelerometerInput();
//#endif
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || UNITY_ANDROID
            RayHits();
#endif

#pragma TEST
#region
            try
            {
                var delta2 = new Vector2(Input.acceleration.x * 2.45f, Input.acceleration.y * 2.45f);
                pos = _guiPos.position;
                pos += delta2;
                _guiPos.position = pos;
                DebugPanel.AddText(_guiPos.ToString() + _player.transform.position, true);
            }
            catch(System.Exception e)
            {
                DebugPanel.AddText(e.Message, true);
            }
#endregion
        }
	}

    void FixedUpdate()
    {
        if (_target == null)
            GetTarget();
        _player.transform.position = Vector3.MoveTowards(_player.transform.position, _target.transform.position, Time.deltaTime * AppSettings.speed );
    }

    private void RayHits()
    {
        Rect toCheck = new Rect(_guiPos.position.x - _guiPos.width / 2, _guiPos.position.y - _guiPos.height / 2, _guiPos.width, _guiPos.height);
        if( toCheck.Contains ( _player.transform.position ))
        {
            Debug.Log("DONE");
            DebugPanel.AddText(_guiPos.position.ToString() + _player.transform.position.ToString() + "COLLIDED", true);
        }
        else
        {
            DebugPanel.AddText("", true);
        }

        Vector3 leftTop = new Vector3(_guiPos.position.x, 0, _guiPos.position.y);
        Vector3 rightTop = new Vector3(_guiPos.position.x + _guiPos.width, 0, _guiPos.position.y);
        Vector3 leftBottom = new Vector3(_guiPos.x, 0, _guiPos.height + _guiPos.position.y);
        Vector3 rightBottom = new Vector3(_guiPos.x + _guiPos.width, 0, _guiPos.y + _guiPos.height);
        Debug.DrawLine(leftTop, rightTop);
        Debug.DrawLine(leftTop, leftBottom);
        Debug.DrawLine(leftBottom, rightBottom);
        Debug.DrawLine(rightBottom, rightTop);
    }

    private void AccelerometerInput()
    {
        //DebugPanel.AddText("TRUE");
        var delta = new Vector2(Input.acceleration.x * 2.45f, Input.acceleration.y * 2.45f);
        var pos = _guiPos.position;
        pos += delta;
        _guiPos.position = pos;
        DebugPanel.AddText(_guiPos.ToString() + _player.transform.position, true);
    }
}
