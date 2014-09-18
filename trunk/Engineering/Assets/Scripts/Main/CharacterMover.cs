using UnityEngine;
using System.Collections;
using MAIN_SETTINGS;
using System;

[Serializable]
public class characterMeta
{
    public GameObject m_character;
    public GameObject m_start;
    public GameObject m_end;
    public bool isEnabled
    {
        get
        {
            if (m_character != null)
                return m_character.active;
            else
                return false;
        }
        set
        {
            if ( m_character != null )
                m_character.active = value;
        }
    }

    public characterMeta()
    {
        isEnabled = false;
    }
}
public class CharacterMover : MonoBehaviour {
    public GUITexture __bgObj;
    public characterMeta[] m_chars = new characterMeta[3];
	// Use this for initialization
	void Start () 
    {
        var diff = Settings.m_difficulty;
        if ( diff == Difficulty.Easy )
        {
            m_chars[0].isEnabled = true;
        }
        else
        if ( diff == Difficulty.Medium )
        {
            m_chars[1].isEnabled = true;
            m_chars[0].isEnabled = true;
        }
        else
        {
            m_chars[0].isEnabled = true;
            m_chars[1].isEnabled = true;
            m_chars[2].isEnabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        MoveChar(m_chars[0]);
        MoveChar(m_chars[1]);
        MoveChar(m_chars[2]);

        InvokeEventsIfNeeded();
	}

    void FixedUpdate()
    {
        CheckAccInput();

    }

    private void CheckAccInput()
    {
        var delta2 = new Vector2(Input.acceleration.x * 2.45f, Input.acceleration.y * 2.45f);
    }
    private void InvokeEventsIfNeeded()
    {
        foreach( var t in m_chars )
        {
            if ( t.isEnabled )
            {
                var dist = Math.Abs(t.m_character.transform.position.x - t.m_end.transform.position.x);
                if  ( dist < 10 )
                {
                    EndLevel.isOver = true;
                }
            }
        }
    }

    private void MoveChar(characterMeta characterMeta)
    {
        if ( !characterMeta.isEnabled )
        {
            return;
        }

        var speed = Settings.m_currentLevelSpeed * Time.deltaTime ;
        var start = characterMeta.m_start;
        var end = characterMeta.m_end;

        var oldPos = characterMeta.m_character.transform.position;
        var newPos = Vector3.MoveTowards(characterMeta.m_character.transform.position, end.transform.position, speed);
        newPos.y = oldPos.y;
        newPos.z = oldPos.z;

        characterMeta.m_character.transform.position = newPos;
    }
}
