using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightControl : MonoBehaviour {

    private Light FlashLight;
  
    void Start()
    {
        FlashLight = GetComponent<Light>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))//only activated when you press down once (Mouse 1=right mouse button)
        {
            if (FlashLight.enabled == false) //checks if light is already on
            {
                FlashLight.enabled = true;
               


            }
            else
            {
                FlashLight.enabled = false;
              
            }
        }
    }
}
