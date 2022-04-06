using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{

    private float timer = 0.0f;
    public float bobbingSpeed = 0.15f; //Frequency of camera shake
    public float bobbingAmount = 0.075f; //Intensity of camera shake
    public float midpoint = 1.75f; //Height of camera


    /*public float SprintBobbingSpeed = 0.3f;
    public bool checkIfIsSprinting;
    CrouchAndSprint sprintScript*/

    /*public void Start()
    {
        sprintScript = gameObject.GetComponent<CrouchAndSprint>();
        checkIfIsSprinting = sprintScript.isSprinting;
    }*/

    void Update()
    {
        float waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 cSharpConversion = transform.localPosition;

        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            timer = 0.0f;
        }
        else
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }

        /*if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0 && checkIfIsSprinting)
        {
            timer = 0.0f;
        }
        else
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + SprintBobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }*/



        if (waveslice != 0)
        {
            float translateChange = waveslice * bobbingAmount;
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            cSharpConversion.y = midpoint + translateChange;
        }
        else
        {
            cSharpConversion.y = midpoint;
        }

        transform.localPosition = cSharpConversion;
    }
}
