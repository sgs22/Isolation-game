using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchAndSprint : MonoBehaviour {

	//private float crouchSpeed = 2f;
	private float speed = 3f; //walk speed
	private float sprintSpeed = 5f; //run speed
	public bool isSprinting = false;

	private float sprintBobSpeed = 0.21f;
	private float sprintBobAmount = 0.95f;
    private float walkBobSpeed = 0.15f;
    private float walkBobAmount = 0.075f;

	
	public float stamina = 20.0f; //current stamina
	public float maxStamina = 20.0f; //max stamina
	
	public const float staminaDeplete = 4.0f; //stamina deplete rate
	public const float staminaRegen = 2.0f; //stamina regen rate
	
	public const float staminaTimeRegen = 2.5f; //time takes to start regen
	public float staminaRegenTimer = 0.0f; //timer to count time to regen
	
	Animator anim;
		
	CharacterController characterCollider;
	characterController characterMovement;
	HeadBob characterHeadbob;

    public AudioSource audioSource;

		
	// Use this for initialization
	void Start () {
		characterCollider = gameObject.GetComponent<CharacterController>();
		characterMovement = gameObject.GetComponent<characterController>();
		characterHeadbob = gameObject.GetComponent<HeadBob>();

        audioSource = GameObject.Find("breathClips").GetComponent<AudioSource>();

        //float CSbobAmount = characterHeadbob.bobbingAmount;
        //float CSbobSpeed = characterHeadbob.bobbingSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
		isSprinting = Input.GetKey("left shift") && stamina > 0;
		
		if (isSprinting)
		{
			characterMovement.speed = sprintSpeed;

            //characterHeadbob.bobbingSpeed = sprintBobSpeed;
            //characterHeadbob.bobbingAmount = sprintBobAmount;

            stamina = Mathf.Clamp(stamina - (staminaDeplete * Time.deltaTime), 0.0f, maxStamina);
			staminaRegenTimer = 0.0f;
		}
		else
		{
			characterMovement.speed = speed; //if not sprinting return to default speed
            //characterHeadbob.bobbingSpeed = walkBobSpeed;
            //characterHeadbob.bobbingAmount = walkBobAmount;
		}
		if (staminaRegenTimer >= staminaTimeRegen)
			stamina = Mathf.Clamp(stamina + (staminaRegen * Time.deltaTime), 0.0f, maxStamina); //stamina regen only after timer reaches time to regen
		else
			staminaRegenTimer += Time.deltaTime;

        if (stamina == 0f)
        {
            isSprinting = false;
        }

        if (stamina < 10 && audioSource.isPlaying == false)
        {
            audioSource.volume = UnityEngine.Random.Range(0.85f, 1f);
            audioSource.pitch = UnityEngine.Random.Range(0.85f, 1f);
            audioSource.Play();
        }
		
		/*stamina = Mathf.Clamp01(stamina);*/
		
		//staminaBar.sliderValue = stamina;
		
	}
	
	
	/*void Animating(float moveHorizontal, float moveVertical)
    {
		bool SprintAnim = isSprinting || moveVertical != 0f;
		
        // Create a boolean that is true if either of the input axes is non-zero.
		anim.SetBool("IsRunning", SprintAnim);
    }*/
}
