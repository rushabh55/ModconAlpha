using UnityEngine;
using System.Collections;

public class Jukebox : MonoBehaviour {
    public AudioSource m_jukeboxSongs;
	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
        SoundManager.PlaySafe(ref m_jukeboxSongs, true);        
	}
}
