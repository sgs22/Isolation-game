using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public string InteractButton;
    public float InteractDistance = 3f; //Distance at which the character is able to interact with something
    public LayerMask InteractLayer; // Tells player that it can interact with a certain object(filter)
    public Image InteractIcon; //picture to show player to show if an object is interactable
    public bool IsInteracting; //Checks if there are any current interactions, and doesn't allow any other interactions to take place unless the previous one is finished



    // Start is called before the first frame update
    void Start()
    {   //Set InteractIcon to be invisible 
        if (InteractIcon != null) //Checks if there is an interact icon to begin with
        {
            InteractIcon.enabled = false; //disables it when game starts
        }

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward); //Starts at the transform position(origin of camera) and then forward is the default vector in unity, which is the z axis
        RaycastHit hit; //Creates variable to check what the ray cast has hit
        //Shoots a ray
        if (Physics.Raycast(ray, out hit, InteractDistance, InteractLayer))  //checks if ray hits something with interaction distance with the interact layer enabled
        {
            //Checks if there is no interaction
            if (IsInteracting == false) //looking at something we can interact with, which enables the interact icon, to make player aware that they can interact with object
            {
                if (InteractIcon != null)
                {
                    InteractIcon.enabled = true;


                    // PickUp.enabled = true;
                    //PickUpText.gameObject.SetActive(true);
                }

                //if interact button is pressed
                if (Input.GetKeyDown("e"))

                {
                    //if it is a note
                    if (hit.collider.CompareTag("Note"))
                    {
                        // picks up note
                        hit.collider.GetComponent<Note>().ShowNoteImage();
                        //  PickUpText.gameObject.SetActive(false);
                        // PickUp.enabled = false;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        InteractIcon.enabled = false;
                    }
                }
            }
            else
            {
                //PickUpText.gameObject.SetActive(false);
                InteractIcon.enabled = false;
                //PickUp.enabled = false;



            }

        }
        else
        {
            //PickUpText.gameObject.SetActive(false);
            InteractIcon.enabled = false;
            //PickUp.enabled = false;



        }
    }
}

