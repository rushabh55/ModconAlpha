using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {
    public static bool isOver = false;
    public Rect m_boxPosition;
    
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
            Time.timeScale = 0;
            GUI.Box(m_boxPosition, "");
            var continueRect = new Rect(m_boxPosition.x, m_boxPosition.y + 100, 400, 80);
            if ( GUI.Button(continueRect, m_content ) )
            {
                Application.LoadLevel(1);
            }
        }
    }

    public GUIContent m_content;
}
