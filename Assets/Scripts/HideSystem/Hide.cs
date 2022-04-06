using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hide : MonoBehaviour
{
    public GameObject Player;
    public GameObject MainCamera;
    public GameObject HidingCamera;
    public Image GuiEnter;
    public Image GuiExit;
    public AudioClip lockerSound;
    public AudioSource BreathingSound;
    public AudioSource lockerSoundEntry;
    private PlayerController playerController;
    private PlayerHealth playerHealth;


    public bool activateTrigger;
    public bool isActive;
    public bool isInArea;

    // Start is called before the first frame update
    void Start()
    {
        HidingCamera.SetActive(false);
        GuiEnter.enabled = false;
        GuiExit.enabled = false;


        BreathingSound.enabled = false;
        lockerSoundEntry.enabled = false;

        playerController = Player.GetComponent<PlayerController>();
        playerHealth = Player.GetComponent<PlayerHealth>();


    }

    // Update is called once per frame
    void Update()
    {
        if (isActive && isInArea)
            activateTrigger = true;

        if (activateTrigger)
        {
            lockerSoundEntry.enabled = true;
            Hiding();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isActive == false)
                isActive = true;
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            isActive = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isInArea = true;
            GuiEnter.enabled = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isInArea = false;
            GuiEnter.enabled = false;
        }
    }

    public void Hiding()
    {

        BreathingSound.enabled = true;

        GuiEnter.enabled = false;
        GuiExit.enabled = true;

        Player.SetActive(false);
        HidingCamera.SetActive(true);

        playerHealth.enabled = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<AudioSource>().PlayOneShot(lockerSound);
            BreathingSound.enabled = false;
            activateTrigger = false;
            Player.SetActive(true);
            playerHealth.enabled = true;
            HidingCamera.SetActive(false);
            MainCamera.SetActive(true);
            GuiExit.enabled = false;
        }
    }

}








