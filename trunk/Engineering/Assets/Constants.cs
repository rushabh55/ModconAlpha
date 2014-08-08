using UnityEngine;
using System.Collections;

public static class AppSettings
{
    //Public
    public static float speed
    {
        get
        {
            return m_speed;
        }
        set
        {
            m_speed = value;
        }
    }

    public static short screenWidth
    {
        get
        {
            return (short)Screen.width;
        }
    }

    public static short screenHeight
    {
        get
        {
            return (short)Screen.height;
        }
    }

    public static float formFactor
    {
        get
        {
            return (float)Screen.width / Screen.height;
        }
    }

    //Encapsulated
    private static float m_speed = 15f;
}