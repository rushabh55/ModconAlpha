using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using MAIN_SETTINGS;
public class BinaryLoader : MonoBehaviour {
    //private string m_pathPrefix = Settings.PERSISTENTDATAPATH + "/level";
    private int m_levelNo = 1;
    public GameObject[] m_levelPrefabs;

    public static GameObject[] m_sLevelPrefabs;

	// Use this for initialization
	void Start () 
    {
	    if ( m_sLevelPrefabs == null )
        {
            m_sLevelPrefabs = m_levelPrefabs;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
