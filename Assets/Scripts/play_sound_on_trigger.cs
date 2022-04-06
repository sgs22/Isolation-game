using UnityEngine;
using System.Collections;

public class play_sound_on_trigger : MonoBehaviour
{
    public bool activateTrigger = false;

    public GameObject Sound;


    void Start()
    {
        Sound.SetActive(false);
    }


    void Update()
    {

        if (activateTrigger)
        {
            Sound.SetActive(true);
            Destroy(this.gameObject);
        }

    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            activateTrigger = true;
        }

    }


    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            activateTrigger = false;
        }

    }
}