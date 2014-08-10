using UnityEngine;
using System.Collections;
using System;

public class PauseScript : MonoBehaviour {
    const Int16 WIDTH = 650;
    const Int16 HEIGHT = 400;
    static Int32 screenWidth = Screen.width;
    static Int32 screenHeight = Screen.height;
    private Rect _boxPosition;

    private static float timeScale = 0;
    public static bool isPaused;

    private Rect _resumeRect;

	// Use this for initialization
	void Start ()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        _boxPosition = new Rect((screenWidth >> 1) - (WIDTH >> 1), (screenHeight >> 1) - (HEIGHT >> 2), WIDTH, HEIGHT);
        _resumeRect = new Rect(_boxPosition.x, _boxPosition.y +( (int)_boxPosition.height >> 2), _boxPosition.width, (int)_boxPosition.height >> 3);
        isPaused = false;
        timeScale = Time.timeScale;
	}
	
    void Awake()
    {
         screenWidth = Screen.width;
         screenHeight = Screen.height;

         _boxPosition = new Rect((screenWidth >> 1) - (WIDTH >> 1), (screenHeight >> 1) - (HEIGHT >> 2), WIDTH, HEIGHT);
         _resumeRect = new Rect(_boxPosition.x, _boxPosition.y + ((int)_boxPosition.height >> 2 ), _boxPosition.width, (int)_boxPosition.height >>3);
        
         timeScale = Time.timeScale;
    }
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            SwitchPauseState( isPaused );
        }
	}

    private void SwitchPauseState( bool state )
    {
        if ( state )
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = timeScale;
        }
        
    }

    void OnGUI()
    {
        if (isPaused)
        {
            GUI.Box(_boxPosition, "Game Paused!");
            DebugPanel.AddText(_boxPosition.ToString(), true);
            GUI.skin.box.fontSize = 50;

            if ( GUI.Button (_resumeRect, "Resume"))
            {
                isPaused = !isPaused;
                SwitchPauseState(isPaused);
            }
        }
    }
}
