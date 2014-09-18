using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {
    public static bool isOver = false;
    public Rect m_boxPosition;
    private double deltaTime = 0; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if ( isOver )
        {
            deltaTime = Time.timeScale ;
            Time.timeScale = 0;
            var continueRect = new Rect( (int)(Screen.width - m_boxPosition.width) >> 1 , (int)(Screen.height - m_boxPosition.height )>> 1, m_boxPosition.width, m_boxPosition.height);

            GUI.Box(new Rect(continueRect.x, continueRect.y, m_boxPosition.width, m_boxPosition.height), "");
            continueRect.width -= 100;
            continueRect.x += 100 >> 1;
            continueRect.y += 100 >> 1;
            continueRect.height -= 200;
            if ( GUI.Button(continueRect, m_content ) )
            {
                Time.timeScale = (float)deltaTime;
                isOver = false;
                Application.LoadLevel(1);
            }
        }
    }

    public GUIContent m_content;
}
