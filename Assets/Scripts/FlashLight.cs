using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public float a;
    public float b;
    public float c;
    public float d;

    public int batLevel;

    public Light FLight;
    public bool isOn;
    public float timer;

    void Start()
    {
        FLight = GetComponent<Light>();
        batLevel = 101;
        minusBat();
        isOn = true;
    }

    void minusBat()
    {
        if (isOn)
        {
            batLevel -= 1;
        }
    }

    void Update()
    {

        if (timer >= 0)
        {
            if (isOn)
            {
                timer -= Time.deltaTime;
            }
        }

        if (timer <= 0)
        {
            timer = 5;
            minusBat();
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            FLight.enabled = !FLight.enabled;

            if (!isOn)
            {
                isOn = true;
            }
            else
            {
                isOn = false;
            }

        }

        if (batLevel == 0)
        {
            batLevel = 0;
            FLight.enabled = false;
            isOn = false;
        }

    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, Screen.height / 1.21f, Screen.width / 6.16f, Screen.height / 19.58f), batLevel.ToString());
    }
}
