using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public Image NoteImage;
    public GameObject HideNoteButton;
    //public AudioClip PickUpSound;
    public GameObject Player;
    public GameObject MainCamera;
     public GameObject CursorImage;
     //public GameObject PickUpText;
    //public bool NoteEnabled;
  // public Text PickUp;

    // Start is called before the first frame update
    void Start()
    {
        NoteImage.enabled = false;
        HideNoteButton.SetActive(false);
        Cursor.visible = false;
       // PickUp.enabled = false;
        //PickUpText.gameObject.SetActive(true);
    }

    void Update()
    {


        if (NoteImage.enabled)
        {
            Player.GetComponent<Camera_Control>().enabled = false;
            MainCamera.GetComponent<Camera_Control>().enabled = false;
            Player.GetComponent<characterController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //PickUpText.gameObject.SetActive(false);
            // PickUp.enabled = false;
        
           
        }
    }



    public void ShowNoteImage()

    {

        NoteImage.enabled = true;
        //PickUpText.SetActive(false);
        //GetComponent<AudioSource>().PlayOneShot(PickUpSound);
        HideNoteButton.SetActive(true);
        Player.GetComponent<Camera_Control>().enabled = false;
        MainCamera.GetComponent<Camera_Control>().enabled = false;
        Player.GetComponent<characterController>().enabled = false;

        CursorImage.SetActive(false);



        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //PickUp.enabled = false;


    }


    public void HideNoteImage()
    {
        NoteImage.enabled = false;
        //GetComponent<AudioSource>().PlayOneShot(PickUpSound);
        HideNoteButton.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Player.GetComponent<Camera_Control>().enabled = true;
        MainCamera.GetComponent<Camera_Control>().enabled = true;
        Player.GetComponent<characterController>().enabled = true;
        // PickUpText.SetActive(false);
        // PickUpText.gameObject.SetActive(false);
        //PickUp.enabled = false;

    }
}
    


