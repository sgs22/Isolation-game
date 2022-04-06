using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flash : MonoBehaviour

{
    private Light FlashLight;               //Reference to flashlight
    public AudioClip TorchSound;            //Audio for the flashlight
    public AudioClip BatteryPickup;

    public int MaxBatteryPower = 200;    //Maximum Battery 
    public float CurrBatteryPower = 0f;    // Current Battery Power

    public float LowPowerIntensity = 3f;    // low power intensity
    public float LowPowerSpotAngle = 40f;   // low power spot angle
    public float LowPowerRange = 20f;      // low power range

    public float HighPowerIntensity = 6f;    // high power intensity
    public float HighPowerSpotAngle = 20f;   // high power spot angle
    public float HighPowerRange = 30f;       // high  power range

    public float LowDrainBatterySpeed = 2.5f; // When power is low, battery drains slower
    public float HighDrainBatterySpeed = 5f; // When power if high, battery drains faster

    public float MaxFlickerSpeed = 1f;   //Maximum light flicker speed
    public float MinFlickerSpeed = 0.1f; //Minimum light flicker speed


    public float BatteryBarLength;   //Battery Bar Length


    // Start is called before the first frame update
    void Start()
    {
        FlashLight = GetComponentInChildren<Light>(); // Gets light component and names it FlashLight 
        FlashLight.enabled = false; // We don't want it to be enabled when the game starts 
        CurrBatteryPower = MaxBatteryPower; // When game starts, battery will begin at 100
    }

    // Update is called once per frame
    void Update()
    {


        BatteryBarLength = Screen.width / 4 * (CurrBatteryPower / (float)MaxBatteryPower); //Length of the initial battery bar will be a quarter of our screen width and it will adjust itself as the battery starts to drain

        if (Input.GetButtonDown("FlashLight")) // Creates the button, and the button can turn the flashlight on as well as off.
        {
            GetComponent<AudioSource>().PlayOneShot(TorchSound); //Plays audio clip once when f is clicked
            FlashLight.enabled = !FlashLight.enabled; // which is done here ( on and off loop)
        }

        if (Input.GetMouseButton(1) && FlashLight.enabled == true) // if mouse button(right) is held and flashlight is on
        {
            FlashLight.intensity = HighPowerIntensity;           // Flash Light intensity will become high
            FlashLight.spotAngle = HighPowerSpotAngle;          // Flash Light spot angle will become high
            FlashLight.range = HighPowerRange;                  // Flash Light range will become high
        }
        else
        {

            FlashLight.intensity = LowPowerIntensity;           // Flash Light intensity will become low
            FlashLight.spotAngle = LowPowerSpotAngle;          // Flash Light spot angle will become low
            FlashLight.range = LowPowerRange;                  // Flash Light spot angle will become low 

        }

        if (CurrBatteryPower > MaxBatteryPower)               // Current battery power should not be able to exceed Maximum Battery power
        {
            CurrBatteryPower = MaxBatteryPower;
        }

        if (CurrBatteryPower < 0)                              //Does not allow current battery power to drop below 0
        {
            CurrBatteryPower = 0;
        }

        if (CurrBatteryPower < 10)
        {
            StartCoroutine("FlashLightModifier");    //If current battery drops below 10, the flash light will start to flicker
        }

        if (CurrBatteryPower > 10)
        {
            StopCoroutine("FlashLightModifier");   //If battery is picked up and it goes up 10, the flash light should not flicker
        }

        if (CurrBatteryPower == 0)
        {
            StopCoroutine("FlashLightModifier");
            FlashLight.enabled = false;
            return;
        }

        if (FlashLight.enabled)
        {
            CurrBatteryPower -= LowDrainBatterySpeed * Time.deltaTime; // When flashlight is turned on(default being low power),subtract low drain speed from current battery power 
        }

        if (Input.GetMouseButton(1) && FlashLight.enabled == true)
        {
            CurrBatteryPower -= HighDrainBatterySpeed * Time.deltaTime; // When high intensity of light is activated when right mouse button is clicked, start draining the battery even quicker
        }


    }



    IEnumerator FlashLightModifier()
    {
        FlashLight.enabled = true;
        yield return new WaitForSeconds(UnityEngine.Random.Range(MinFlickerSpeed, MaxFlickerSpeed));

        FlashLight.enabled = false;
        yield return new WaitForSeconds(UnityEngine.Random.Range(MinFlickerSpeed, MaxFlickerSpeed));
    }


    public void AddBattery(float BatteryPowerAmount)
    {
        CurrBatteryPower += BatteryPowerAmount;   //Adds more battery to current battery
        /*if (BatteryPickup != null)
        {
            GetComponent<AudioSource>().clip = BatteryPickup;    //Plays audio only if assinged 
            GetComponent<AudioSource>().Play();
        }*/
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(5, 35, BatteryBarLength, 20), "Flash Light Battery"); //Displays battery power
    }
}
