using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {
	
	public GameObject item;
	public int ID;
	public string type;
	public string description;
	public bool empty;
	public Sprite icon;
    
	
	
	
	// Use this for initialization
	private void Start () 
	{
		//slotIconGO = transform.GetChild(0);
	}
	
	// Update is called once per frame
	public void UpdateSlot () 
	{
		this.GetComponent<Image>().sprite = icon;
	}
}
