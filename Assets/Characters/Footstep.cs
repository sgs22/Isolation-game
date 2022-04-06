using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour {
	
	//CharacterController CharController;
    characterController characterController;

    public bool audioIsPlaying;

	// Use this for initialization
	void Start () {
        characterController = GetComponent<characterController>();

        audioIsPlaying = GetComponent<AudioSource>().isPlaying;
	}
	
	// Update is called once per frame
	void Update () {
		if (characterController.moveVerticalSpeed == true && GetComponent<AudioSource>().isPlaying == false )
		{
			GetComponent<AudioSource>().volume = UnityEngine.Random.Range(0.2f, 0.3f);
			GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(0.6f, 0.8f);
			GetComponent<AudioSource>().Play();
		}
        if (characterController.moveHorizontalSpeed == true && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().volume = UnityEngine.Random.Range(0.2f, 0.3f);
            GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(0.6f, 0.8f);
            GetComponent<AudioSource>().Play();
        }
    }
}
