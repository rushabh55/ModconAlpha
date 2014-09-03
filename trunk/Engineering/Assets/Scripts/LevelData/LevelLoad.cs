using UnityEngine;
using System.Collections;
using MAIN_SETTINGS;
public class LevelLoad 
{
    public enum LEVEL_NUM
    {
        INVALID_LVL = 0,

        LV_01 = 1 << 1,
        LV_02 = 1 << 2,
        LV_03 = 1 << 3,
        LV_04 = 1 << 4,
        LV_05 = 1 << 5,
        LV_06 = 1 << 6,
        LV_07 = 1 << 7,
        LV_08 = 1 << 8,
        LV_09 = 1 << 9,
        LV_10 = 1 << 10,
        LV_11 = 1 << 11,
        LV_12 = 1 << 12,
        LV_13 = 1 << 13,
        LV_14 = 1 << 14,
        LV_15 = 1 << 15,

        NUM_LEVELS = 1 << 16
        //uint32 will do for this
    };
    private static LevelLoad m_instance = null;
    public static LevelLoad GetInstance()
    {
        if ( m_instance != null )
        {
            m_instance = new LevelLoad();
            
        }
        return m_instance;
    }

    
    public LEVEL_NUM m_levelNum = LEVEL_NUM.INVALID_LVL;
	// Use this for initialization
    private LevelLoad() 
    {
        if (m_levelNum == LEVEL_NUM.INVALID_LVL || m_levelNum == LEVEL_NUM.NUM_LEVELS)
        {
            m_levelNum = LEVEL_NUM.LV_01;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
