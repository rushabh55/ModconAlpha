using UnityEngine;
using System.Collections;

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
        //short selectedIndex = (short)new System.Random().Next(0, m_skyboxes.Length);
        //var selectedSkybox = m_skyboxes[selectedIndex];
        //RenderSettings.skybox = selectedSkybox;
        ////if < 4

        //if ( selectedIndex < 4 )
        //{
        //    m_sunLensFlare.active = false;
        //}

        //var selectedWeatherEffect = m_weatherEffects[new System.Random().Next(0, m_weatherEffects.Length)];
        //selectedWeatherEffect.SetActive(true);
        //selectedWeatherEffect.isStatic = false;
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
