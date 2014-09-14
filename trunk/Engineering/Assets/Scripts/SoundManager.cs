using UnityEngine;
using System.Collections;
using MAIN_SETTINGS;

public class SoundManager {

	public static void PlaySound( ref AudioSource sndInstance, bool loop = false )
	{
		if ( Settings.IsMute )
			return;
        sndInstance.loop = loop;
		sndInstance.Play();
	}

	public static void PlaySafe ( ref AudioSource sndInstance, bool loop = false )
	{
		if ( Settings.IsMute )
			return;
        sndInstance.loop = loop;
		if ( !sndInstance.isPlaying ) 
		{
			sndInstance.Play();
		}
	}

	public static void Pause ( ref AudioSource sndInstance )
	{
		if ( sndInstance.isPlaying )
		{
			sndInstance.Play();
		}
	}
}
