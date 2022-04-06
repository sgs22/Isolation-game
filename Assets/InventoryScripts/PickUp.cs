using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject[] inventoryIcons;
    public int textCount;

    private Flash FlashLight;

    private void Awake()
    {
        FlashLight = FindObjectOfType<Flash>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (Transform child in inventoryPanel.transform)
        {
            if (child.gameObject.tag == collision.gameObject.tag)
            {
                string c = child.Find("Text").GetComponent<Text>().text;
                textCount = int.Parse(c) + 1;
                child.Find("Text").GetComponent<Text>().text = "" + textCount;
                return;
            }
        }

    }
  
}
