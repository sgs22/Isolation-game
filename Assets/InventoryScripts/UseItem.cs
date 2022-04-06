using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{
    public Slider healthSlider;
    public int addHealth = 10;

    public float BatteryPowerAmount = 100f;
    private Flash FlashLight;

    private void Awake()
    {
        FlashLight = GameObject.FindObjectOfType<Flash>();
    }


    public void Use()
    {
        if (System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) >= 1)
        {
            int tcount = System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) - 1;
            this.transform.Find("Text").GetComponent<Text>().text = "" + tcount;
            healthSlider.value += addHealth;
            
        }
        
    }


    public void useBattery()
    {
        if (System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) >= 1)
        {
            int tcount = System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) - 1;
            this.transform.Find("Text").GetComponent<Text>().text = "" + tcount;
            FlashLight.AddBattery(BatteryPowerAmount);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
