using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

	public GameObject player;			//Public variable to store a reference to the player game object
	private Vector3 offset;				//Private variable to store the offset distance to the camera from the player

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 5F;
	public float sensitivityY = 5F;
	public float minimumX = -90F;
	public float maximumX = 90F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationY = 0F;
	
	void Update ()
	{
		if (axes == RotationAxes.MouseXAndY)
		 {
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
         
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
         
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
		  transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
         
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}
	}
 
	void Start ()
	{
		//calculate and store the offset value by getting the distance between the players position and cameras postion.
		offset = transform.position - player.transform.position;

		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
        GetComponent<Rigidbody>().freezeRotation = true;
	}

	void LateUpdate () 
	{
		//set the position of the cameras transform to be the same as the players, but offset by the calculated offset distnace. 
		transform.position = player.transform.position + offset;
	
	}
}
