using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
	//private Renderer renderer;
	private Animator anim;
	private bool isAware = false;

	public Transform target;
	UnityEngine.AI.NavMeshAgent agent;
	
	public float fov = 120f;
	public float viewDistance = 20f;
	//public float chasingTime = 20f;
	//public float SearchTime = 2.5f;

	void Start()
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		//renderer = GetComponent<Renderer>(); 

		anim = GetComponent<Animator>();
		anim.SetBool("IsWalking",false);
	}


	void Update () 
	{
		if (isAware)
		{
			agent.SetDestination(target.position);
			anim.SetBool("IsWalking",true);
		}
		else
		{
			SearchForPlayer();
			anim.SetBool("IsWalking",false);
		}
	}

	public void SearchForPlayer()
	{
		if (Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(target.transform.position)) < fov / 2f)
		{
			if (Vector3.Distance(target.transform.position, target.position) < viewDistance)
			{
				RaycastHit hit;
				if (Physics.Linecast(transform.position, target.transform.position, out hit, -1))
				{
					if (hit.transform.CompareTag("Player"))
					{
						OnAware();
					}
				}
			}
		}
	}

	public void OnAware()
	{
		isAware = true;
		/*
		chasingTime -= SearchTime * Time.deltaTime;
		if (chasingTime < SearchTime)
		{
			isAware = false;
		}
		*/
	}
}
