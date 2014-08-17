using UnityEngine;
using System.Collections;

public class EventInvoker : MonoBehaviour {

    public GameObject player;
    public GameObject globals;
    public SimplePlayerTranslate m_sPlayerTranslate;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    void OnCollisionEnter(Collision collider)
    { 
        if(collider.collider.Equals (player))
        {
            player.renderer.enabled = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.Equals(player.collider))
        {
            foreach (var t in player.GetComponentsInChildren<Renderer>())
            {
                m_sPlayerTranslate.InitializePosition();
            }
        }
    }
}
