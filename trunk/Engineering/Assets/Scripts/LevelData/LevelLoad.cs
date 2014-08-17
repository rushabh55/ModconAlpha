using UnityEngine;
using System.Collections;
using MAIN_SETTINGS;
public class LevelLoad : MonoBehaviour {
    private LEVEL_NUM m_levelNum = Settings.m_currentLevel;
	// Use this for initialization
	void Start () 
    {
	    if ( m_levelNum == LEVEL_NUM.INVALID_LVL || m_levelNum == LEVEL_NUM.NUM_LEVELS )
        {
            
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
