using UnityEngine;
using System.Collections;
using MAIN_SETTINGS;

public class TapMouseRayCast : MonoBehaviour 
{
    public Camera _camera;
    public GameObject[] _objsToHide;
    public GameObject _mainMenu;
    public GameObject _settingsMenu;

	public AudioSource _clickSound;

    public int m_animSpeed;
    public enum UIState
    {
        MAINMENU = 1,
        OPTIONS = 2,
        LEVELSELECT = 3
    };

    public enum AnimState
    {
        NO_ANIM = 0,
        MAINMENU_TO_OPTIONS = 1,
        OPTIONS_TO_MAINMENU = 2,
        NUM_STATES
    }

    public AnimState m_currAnimState;
    public UIState m_currentState;
    public Texture2D _mouseTexture;

	// Use this for initialization
	void Start () 
    {
        Application.targetFrameRate = 3000;
        m_currentState = UIState.MAINMENU;

        Debug.Log(Application.loadedLevelName);

        
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if( Input.touchCount > 0)
        {
            CheckForRayCollisions(Input.touches[0].position);
        }
        else
        if( Input.mousePresent && Input.GetMouseButtonUp(0))
        {
            CheckForRayCollisions(Input.mousePosition);
        }
        if ( Input.GetKey(KeyCode.Backspace ) || Input.GetKey(KeyCode.Escape) )
        {
            Application.Quit();
        }       
	}

    void FixedUpdate()
    {
        if (m_currAnimState == AnimState.NO_ANIM || m_currAnimState == AnimState.NUM_STATES)
            return;

        if (m_currAnimState == AnimState.MAINMENU_TO_OPTIONS)
        {
            Vector3 newPosition = new Vector3(
                                            _settingsMenu.transform.position.x, 
                                            _camera.transform.position.y, 
                                            _camera.transform.position.z);

            _camera.transform.position = Vector3.MoveTowards(
                                           _camera.transform.position,
                                           newPosition,
                                           Time.deltaTime * m_animSpeed
                                           );

            if ( Vector3.Distance ( newPosition, _camera.transform.position ) < 1 )
            {
                m_currAnimState = AnimState.NO_ANIM;
                _camera.transform.position = newPosition;
            }
        }
        else
        if ( m_currAnimState == AnimState.OPTIONS_TO_MAINMENU )
        {
            Vector3 newPosition = new Vector3(
                                            _mainMenu.transform.position.x,
                                            _camera.transform.position.y,
                                            _camera.transform.position.z);

            _camera.transform.position = Vector3.MoveTowards(
                                           _camera.transform.position,
                                           newPosition,
                                           Time.deltaTime * m_animSpeed
                                           );

            if (Vector3.Distance(newPosition, _camera.transform.position) < 1)
            {
                m_currAnimState = AnimState.NO_ANIM;
                _camera.transform.position = newPosition;
            }
        }
    }

    void CheckForRayCollisions(Vector3 pos)
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = _camera.ScreenPointToRay(pos);
        Debug.DrawLine(ray.origin,ray.direction, Color.green);
        if( Physics.Raycast(ray, out hit, 200 ))
        {
            if (m_currentState == UIState.MAINMENU)
            {
                if ( hit.collider.name == "Play" )
                {
                    try
                    {
						SoundManager.PlaySafe ( ref _clickSound );
						hit.collider.renderer.material.color = Color.green;
                        Application.LoadLevelAsync(1);
                    }
                    catch (System.Exception e)
                    {
                        DebugPanel.AddText(e.Message, true);
                    }
                }
                else
                if ( hit.collider.name == "Options" )
                {
                    try
					{
						SoundManager.PlaySafe ( ref _clickSound );
                        hit.collider.renderer.material.color = Color.green;
                        iTween.RotateTo(hit.collider.gameObject, new Vector3(0, 0, 90), 10);
                        changeState(UIState.OPTIONS);
                    }
                    catch (System.Exception e)
                    {
                        DebugPanel.AddText(e.Message, true);
                    }
                }
            }
            else
            if ( m_currentState == UIState.OPTIONS )
            {
                if ( hit.collider.name == "Back" )
                {
                    try
					{
						SoundManager.PlaySafe ( ref _clickSound );
                        hit.collider.renderer.material.color = Color.green;
                        changeState(UIState.MAINMENU);
                    }
                    catch (System.Exception e)
                    {
                        DebugPanel.AddText(e.Message, true);
                    }
                }

				else
				if ( hit.collider.name == "MuteOn") 
				{
					try 
					{
						SoundManager.PlaySafe ( ref _clickSound );
						Settings.setMute ( true );
					}
					catch ( System.Exception e )
					{
						DebugPanel.AddText ( e.Message, true );
					}
				}
				else
				if ( hit.collider.name == "MuteOff" )
				{
					try
					{
						SoundManager.PlaySafe ( ref _clickSound );
						Settings.setMute( false );
					}
					catch( System.Exception e ) 
					{
						DebugPanel.AddText( e.Message, true );
					}
				}
                else
                if ( hit.collider.name == "Easy")
                {
                    Settings.m_difficulty = Difficulty.Easy;
                }
                else
                if ( hit.collider.name == "Medium")
                {
                    Settings.m_difficulty = Difficulty.Medium;
                }
                else
                if( hit.collider.name == "Hard")
                {
                    Settings.m_difficulty = Difficulty.Hard;
                }
            }

			Debug.Log ( hit.collider.name );
		}
    }

    void OnGUI()
    {
        Cursor.SetCursor(_mouseTexture, Vector2.zero, CursorMode.Auto);
        if ( GUI.Button ( new Rect (400, 100, 400, 100), "Load Level"))
        {
            Application.LoadLevelAdditiveAsync(1);
        }

        if (GUI.Button (new Rect (Screen.width - 250, Screen.height - 80, 250, 80), "Facebook Login"))
        {
            FB.Init(onInitComplete, onHideunity);
            DebugPanel.AddText("Init FB", true);
        }
    }

    private void changeState(UIState state) 
    {
        if (m_currentState == UIState.MAINMENU && state == UIState.OPTIONS)
        {
            m_currAnimState = AnimState.MAINMENU_TO_OPTIONS;
            m_currentState = UIState.OPTIONS;

            
        }
        else
        if ( m_currentState == UIState.OPTIONS && state == UIState.MAINMENU )
        {
            m_currAnimState = AnimState.OPTIONS_TO_MAINMENU;
            m_currentState = UIState.MAINMENU;
        }
    }

    private void onHideunity(bool isUnityShown)
    {
        DebugPanel.AddText("onHideunity" + isUnityShown, true);
    }

    private void onInitComplete()
    {
        FB.Login("user_about_me, user_activities, user_birthday, public_profile, user_friends, email", onLoginCallback);
        DebugPanel.AddText("INIT COMPLETE",true);
    }

    private void onLoginCallback(FBResult result)
    {
        DebugPanel.AddText(result.Text + "LOGGED IN", true);
    }
}
