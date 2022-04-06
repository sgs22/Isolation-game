using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public Transform target;
    AudioSource enemyAudio;

    private Animator anim;

    UnityEngine.AI.NavMeshAgent agent;

    //variables for patrolling
    public GameObject[] waypoints;
    private int waypointInd;
    public float patrolSpeed = 0.5f;

    //variables for Chase
    public float chaseSpeed = 3f;

    //Variables for Attack
    public AudioClip attackClip;
    public float timeBetweenAttacks = 3f;     // The time in seconds between each attack.
    public int attackDamage = 50;
    GameObject player;
    PlayerHealth playerHealth;
    float timer;

    


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("IsWalking", false);

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            Chase();

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                if (timer >= timeBetweenAttacks)  // If the timer exceeds the time between attacks
                {
                    Attack();
                }

            }
        }
        else
        {
            Patrol();
        }
		if (waypoints != null)
        {
            if (!agent.pathPending && agent.remainingDistance < 1f)
            {
                waypointInd = (waypointInd + 1) % waypoints.Length;
            }

        }


        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;


        // If the player has zero or less health...
        if (playerHealth.currentHealth <= 0)
        {
            // ... tell the animator the player is dead.
            anim.SetBool("IsWalking", false);
        }

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        agent.updateRotation = true;
    }

    void Patrol()
    {
        anim.SetBool("IsWalking", false);
        agent.speed = patrolSpeed;
        agent.autoBraking = false;


        if (Vector3.Distance(transform.position, waypoints[waypointInd].transform.position) >= 0.5f) //too far
        {
            FaceTarget();
            agent.SetDestination(waypoints[waypointInd].transform.position); //moves towards first waypoint
            anim.SetBool("IsWalking", true); //plays walking animation
            agent.updateRotation = true;
        }
    }

    void Chase()
    {
        FaceTarget();
        anim.SetBool("IsWalking", true);
        agent.speed = chaseSpeed;
        agent.SetDestination(target.transform.position);
    }

    void Attack()
    {
        // Reset the timer.
        timer = 0f;

        enemyAudio.clip = attackClip;
        enemyAudio.Play();

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            FaceTarget();
            anim.SetBool("Attack", true);
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
        }
    }

    //to visualize the enemy view distance.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
