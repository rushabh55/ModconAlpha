using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class WeatherData
{
    public Material m_material;
    public GameObject m_weatherFX;
}
public class WeatherRandomizer : MonoBehaviour 
{
    public WeatherData[] m_weatherData;
    public LensFlare m_sunLensFlare;

	// Use this for initialization
	void Start () 
    {
	    
	}

    void Awake()
    {
        short selectedIndex = (short)new System.Random().Next(0, m_weatherData.Length);
        var selectedSkybox = m_weatherData[selectedIndex].m_material;
        RenderSettings.skybox = selectedSkybox;
        //if < 4

        if (selectedIndex < 5)
        {
            m_sunLensFlare.active = false;
        }


        var selectedWeatherEffect = m_weatherData[selectedIndex].m_weatherFX;
        selectedWeatherEffect.SetActive(true);
        selectedWeatherEffect.isStatic = false;
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
