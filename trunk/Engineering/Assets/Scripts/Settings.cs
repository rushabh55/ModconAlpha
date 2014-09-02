﻿using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MAIN_SETTINGS
{

//#if UNITY_ANDROID || UNITY_WP8 || UNITY_STANDALONE_WIN


    public class Settings : MonoBehaviour
    {
        public Texture2D m_mouseTexture;

        #region LevelData

        static public float m_currentLevelSpeed = 50;
        #endregion

        static public int m_playerName;
        static public UInt16 SCREENWIDTH
        {
            get
            {
                return m_screenWidth;
            }
        }


        static public UInt16 SCREENHEIGHT
        {
            get
            {
                return m_screenHeight;
            }
        }

        static public double ASPECTRATIO
        {
            get
            {
                return m_aspectRatio;
            }
        }

        static public string PERSISTENTDATAPATH
        {
            get
            {
                return Application.persistentDataPath;
            }
        }

        static public string DATAPATH
        {
            get
            {
                return Application.dataPath;
            }
        }
		static public bool IsMute 
		{
			get 
			{
				return m_isMute;
			}
		}
        private static UInt16 m_screenWidth;
        private static UInt16 m_screenHeight;
        private static double m_aspectRatio;
		private static bool m_isMute;

		public static void setMute ( bool mute )
		{
			m_isMute = mute;
		}

        void Awake()
        {
            
        }

        // This function is called every fixed framerate frame, if the MonoBehaviour is enabled (Since v1.0)
        void FixedUpdate()
        {
            //DebugPanel.AddText(PERSISTENTDATAPATH);
        }

        // LateUpdate is called every frame, if the Behaviour is enabled (Since v1.0)
        void LateUpdate()
        {
        }

        // OnBecameVisible is called when the renderer became visible by any camera (Since v1.0)
        void OnBecameInvisible()
        {
        }

        // OnBecameInvisible is called when the renderer is no longer visible by any camera (Since v1.0)
        void OnBecameVisible()
        {
        }

        // OnPreCull is called before a camera culls the scene (Since v1.0)
        void OnPreCull()
        {
        }

        // OnPreRender is called before a camera starts rendering the scene (Since v1.0)
        void OnPreRender()
        {
        }

        // This function is called when the script is loaded or a value is changed in the inspector (Called in the editor only). (Since v4.2)
        void OnValidate()
        {
        }

        // OnWillRenderObject is called once for each camera if the object is visible (Since v2.0)
        void OnWillRenderObject()
        {
        }

        void OnGUI()
        {
            Cursor.SetCursor(m_mouseTexture, Vector2.zero, CursorMode.Auto);
        }



        public Settings()
        {
            m_screenWidth = (ushort)Screen.width;
            m_screenHeight = (ushort)Screen.height;
            m_aspectRatio = m_screenWidth / (m_screenHeight == (ushort)0 ? (ushort)1 : (ushort)m_screenHeight);
        }

        void Update()
        {
            m_screenWidth = (ushort)Screen.width;
            m_screenHeight = (ushort)Screen.height;
            m_aspectRatio = m_screenWidth / m_screenHeight;
            DebugPanel.AddText("", false);
            List<string> files = Directory.GetFiles(PERSISTENTDATAPATH).ToList();
            Debug.Log("DATA: " + Application.dataPath);
            Debug.Log("PERSISTANT DATA: " + Application.persistentDataPath);
        }
    }


//#endif
}