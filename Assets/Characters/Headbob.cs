using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbob : MonoBehaviour {

	private float timer = 0.0f;
	public float bobbingSpeed = 0.18f; //Frequency of camera shake
	public float bobbingAmount = 0.08f; //Intensity of camera shake
	float midpoint = 2.0f; //Height of camera
  
 	void Update () {
   	float waveslice = 0.0f;
	float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");
  
  	Vector3 cSharpConversion = transform.localPosition; 
  
 		if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0) 
		{
        	timer = 0.0f;
     	}
     	else {
        	waveslice = Mathf.Sin(timer);
        	timer = timer + bobbingSpeed;
			if (timer > Mathf.PI * 2) 
			{
				timer = timer - (Mathf.PI * 2);
        	}
     	}
     	if (waveslice != 0) 
		{
        	float translateChange = waveslice * bobbingAmount;
        	float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
        	totalAxes = Mathf.Clamp (totalAxes, 0.0f, 1.0f);
        	translateChange = totalAxes * translateChange;
        	cSharpConversion.y = midpoint + translateChange;
     	}
     	else {
        	cSharpConversion.y = midpoint;
     	}
  
  	transform.localPosition = cSharpConversion;
  	}
}
