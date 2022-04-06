using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{

    public float speed = 3f; //Character default speed
    public bool moveVerticalSpeed;
    public bool moveHorizontalSpeed;
    Animator anim; //Call Animator controller
    Rigidbody playerRigidbody;
	AudioSource walkingAudio;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
		Cursor.lockState = CursorLockMode.Locked;
		walkingAudio = GetComponent<AudioSource>();

    }

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Locking cursor
    }

    // Update is called once per frame
    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical") * speed;
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        moveVertical *= Time.deltaTime;
        moveHorizontal *= Time.deltaTime;
        Animating(moveHorizontal, moveVertical);

        if(moveVertical != 0)
        {
            moveVerticalSpeed = true;
        }
        else
        {
            moveVerticalSpeed = false;
        }
        if (moveHorizontal != 0)
        {
            moveHorizontalSpeed = true;
        }
        else
        {
            moveHorizontalSpeed = false;
        }

        transform.Translate(moveHorizontal, 0, moveVertical);

        if (Input.GetKeyDown("escape"))
        { 
        Cursor.lockState = CursorLockMode.None;
        }
        
    }

    void Animating(float moveHorizontal, float moveVertical)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = /*moveHorizontal != 0f ||*/ moveVertical != 0f;

        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);

        // Walking Right animation
        bool Walk_R = moveHorizontal > 0f;

        anim.SetBool("WalkingRight", Walk_R);

        // Walking Left animation
        bool Walk_L = moveHorizontal < 0f;

        anim.SetBool("WalkingLeft", Walk_L);
    }
}
