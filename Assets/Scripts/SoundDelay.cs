using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDelay : MonoBehaviour
{
    public AudioSource audioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioClip.PlayDelayed(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
