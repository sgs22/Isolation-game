using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Animation : MonoBehaviour
{
	Animator animator;
	bool attackAnim;
 
	void Start () 
	{
		attackAnim = false;
		animator = GetComponent<Animator> ();
	}
 
	void OnTriggerEnter(Collider col ) 
	{
		if(col.gameObject.tag == "Player")
		{
			attackAnim = true;
			npc ("Attack");
		}
	}
 
	void OnTriggerExit(Collider col ) 
	{
		if(attackAnim)
		{
			attackAnim = false;
		}
	}
 
	void npc(string direction)
	{
		animator.SetTrigger(direction);
	}
}
