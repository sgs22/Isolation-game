/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    public enum RotationAxis // moves camera on the x and y axis
    {
        MouseX = 1, 
        MouseY = 2
    }

    public RotationAxis axes = RotationAxis.MouseX; //Initialise roation 

    public float sensHoriztontal = 10.0f; //sensitivity while looking around horizontally
    public float sensVertical = 10.0f; //sensitivity while looking around vertically

    public float _rotationX = 0; //vertical angle that the player is looking





    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensHoriztontal, 0);
        }
        else if (axes == RotationAxis.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensVertical;



            float rotationY = transform.localEulerAngles.y;//keeps the y angle the same so there is no horizontal rotation

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0); // creates a new vector for stored rotation values


        }
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    public enum RotationAxis // moves camera on the x and y axis
    {
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axes = RotationAxis.MouseX; //Initialise roation 
    public float minimumVert = -45.0f;// minimum vertical rotation
    public float maximumVert = 45.0f;// maximum vertical rotation
    public float sensHoriztontal = 10.0f; //sensitivity while looking around horizontally
    public float sensVertical = 10.0f; //sensitivity while looking around vertically


    public float _rotationX = 0; //vertical angle that the player is looking





    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensHoriztontal, 0);
        }
        else if (axes == RotationAxis.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensVertical;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);//Sets rotation X to maximum or minimum vertical 





            float rotationY = transform.localEulerAngles.y;//keeps the y angle the same so there is no horizontal rotation

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0); // creates a new vector for stored rotation values
            Vector3 movement = new Vector3(_rotationX, rotationY, 0);
            Vector3 relativeMovement = Camera.main.transform.TransformVector(movement);
        }
    }
}
