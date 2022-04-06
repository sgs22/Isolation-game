using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNPC : MonoBehaviour
{
    private GameObject triggeringNPC;
    private bool triggering;

    public AudioSource npcAudio;

    // Update is called once per frame
    void Update()
    {
        if(triggering)
        {
            npcAudio.Play();
        }   
        else
        {
            npcAudio.Stop();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            triggering = true;
            triggeringNPC = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "NPC")
        {
            triggering = false;
            triggeringNPC = null;
        }
    }
}
