using UnityEngine;
using System.Collections;
using MAIN_SETTINGS;
public class LevelLoad 
{
    private static LevelLoad m_instance = null;
    public static LevelLoad GetInstance()
    {
        if ( m_instance != null )
        {
            m_instance = new LevelLoad();
            
        }
        return m_instance;
    }

    
    private LEVEL_NUM m_levelNum = LEVEL_NUM.INVALID_LVL;
	// Use this for initialization
    private LevelLoad() 
    {
	    if ( m_levelNum == LEVEL_NUM.INVALID_LVL || m_levelNum == LEVEL_NUM.NUM_LEVELS )
        {
            m_levelNum = LEVEL_NUM.LV_01;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
