using UnityEngine;
using System.Collections;
using MAIN_SETTINGS;

public class LevelSelector : MonoBehaviour {
    public GameObject[] m_levelSprites = null;
    public Camera m_camera;
    public AudioSource m_click;
    public AudioSource m_levelEnter;
	// Update is called once per frame
	void Update () 
    {
        ProcessTouch();
        ProcessMouse();
	}

    private void ProcessMouse()
    {
        if( Input.mousePresent )
        {
            if (Input.GetMouseButtonDown(0))
            {
                var pos = Input.mousePosition;
                RaycastHit hit = new RaycastHit();
                Ray ray = m_camera.ScreenPointToRay(pos);
                if (Physics.Raycast(ray, out hit, 200))
                {
                    SoundManager.PlaySafe(ref m_click);
                    uint levelNo = (uint)System.Convert.ToInt16(hit.collider.name);
                    LEVEL_NUM level = (LEVEL_NUM)levelNo;
                    Settings.LoadIntoLevel(level);
                    Application.LoadLevel(2);
                    Debug.Log(level);
                    SoundManager.PlaySafe(ref m_levelEnter);
                }
            }
        }
    }

    private void ProcessTouch()
    {
        if (Input.touchCount > 0)
        {
            foreach (var t in Input.touches)
            {
                var pos = t.position;
                RaycastHit hit = new RaycastHit();
                Ray ray = m_camera.ScreenPointToRay(pos);
                if (Physics.Raycast(ray, out hit, 200))
                {
                    SoundManager.PlaySafe(ref m_click);
                    uint levelNo = (uint)System.Convert.ToInt16(hit.collider.name);
                    LEVEL_NUM level = (LEVEL_NUM)levelNo;
                    Settings.LoadIntoLevel(level);
                    Application.LoadLevel(2);
                    Debug.Log(level);
                    SoundManager.PlaySafe(ref m_levelEnter); 
                }
            }
        }
    }
}
