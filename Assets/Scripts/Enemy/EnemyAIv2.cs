using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.XR;
public class EnemyAIv2 : MonoBehaviour
{
    #region Target Settings
    [Header("Target Settings", order = 2)]
    public float lookRadius = 10f;
    public GameObject Player;
    public Transform target;
    #endregion

    private Animator anim;
    UnityEngine.AI.NavMeshAgent agent;

    #region Patrolling Settings
    [Header("Patrolling Settings", order = 2)]
    //variables for patrolling
    public GameObject[] waypoints;
    private int waypointInd;
    public float patrolSpeed = 0.5f;
    private PlayerController playerController;
    #endregion

    #region Chase Settings
    [Header("Chase Settings", order = 1)]
    //variables for Chase
    public float chaseSpeed = 3f;
    #endregion

    #region Attack Settings
    [Header("Attack Settings", order = 4)]
    //Variables for Attack
    public float timeBetweenAttacks = 3f;     // The time in seconds between each attack.
    public int attackDamage = 50;
    private GameObject player;
    private PlayerHealth playerHealth;
    float timer;
    #endregion

    #region Investigate Settings
    [Header("Investigate Settings", order = 4)]
    //variables for investigiating
    public float investigateSpeed = 5f;
    public float investigateWait = 1f;
    private Vector3 investigateSpot;
    private float investigateTimer;
    #endregion

    #region Sight Settings
    [Header("Sight Settings", order = 2)]
    //variables for sight
    public float heightMultiplier;
    public float sightDist = 10;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("IsIdle", true);

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        waypointInd = Random.Range(0, waypoints.Length);

        heightMultiplier = 1.36f;
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
        /*
        //if statement for if player is hiding enemies need to leave and patrol.
        if(playerHealth.enabled == false)
        {
            Investigate();
        }
        */
            

        if (agent.remainingDistance < 2f)
        {
            //waypointInd = (waypointInd + 1) % waypoints.Length; //old version for specific path
            waypointInd = Random.Range(0, waypoints.Length);
        }



        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

    }

    void FixedUpdate()
    {
        Debug.DrawRay(transform.position + (Vector3.up * heightMultiplier), transform.forward * sightDist, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized * sightDist, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized * sightDist, Color.green);
        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, transform.forward, out RaycastHit hit, sightDist))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                Chase();
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized, out hit, sightDist)) 
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                Chase();
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized, out hit, sightDist))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                Chase();
            }
        }
      
     }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void Patrol()
    {
        anim.SetBool("IsIdle", false);
        anim.SetBool("Attack", false);
        anim.SetBool("IsWalking", true);
        agent.speed = patrolSpeed;
        agent.stoppingDistance = 0;
        agent.autoBraking = false;

        if (Vector3.Distance(transform.position, waypoints[waypointInd].transform.position) > 0.1f) //too far
        {
            agent.SetDestination(waypoints[waypointInd].transform.position); //moves towards first waypoint
            anim.SetBool("IsWalking", true); //plays walking animation

        }

        if (agent.remainingDistance < 1f)
        {
            //waypointInd = (waypointInd + 1) % waypoints.Length; //old version for specific path
            waypointInd = Random.Range(0, waypoints.Length);
        }

    }
    //when player is hiding.
    void Investigate() 
    {
        anim.SetBool("IsIdle", false);
        anim.SetBool("Attack", false);
        anim.SetBool("IsWalking", true);
        investigateTimer += Time.deltaTime;
        agent.speed = investigateSpeed;
        agent.SetDestination(investigateSpot);
        if (investigateTimer >= investigateWait)
        {
            Patrol();

        }
    }

    void Chase()
    {
        anim.SetBool("IsIdle", false);
        anim.SetBool("IsWalking", true);
        agent.speed = chaseSpeed;
        agent.stoppingDistance = 2.5f;
        agent.SetDestination(player.transform.position);

    }

    void Attack()
    {
        agent.stoppingDistance = 2;
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
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
