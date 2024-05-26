using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControls : MonoBehaviour
{
    public Transform target; // The target to follow (usually the player)
    private NavMeshAgent agent;
    public float distanceToRun;
    public bool canMove = true;
    
    public Transform[] targets;

    public bool playerClose;

    public PlayerTag tags;
    public PlayerTag otherTags;
    public float ItervalofChanges;

    public float timer;
    void Start()
    {
        tags = GetComponent<PlayerTag>();
        canMove = true;
        agent = GetComponent<NavMeshAgent>();
        if (target == null)
        {
            if (GameManager.instance.Base1Count > GameManager.instance.Base2Count && GameManager.instance.Base1Count > GameManager.instance.Base3Count)
            {
                target = targets[0];
            }

            if (GameManager.instance.Base2Count > GameManager.instance.Base1Count && GameManager.instance.Base2Count > GameManager.instance.Base3Count)
            {
                target = targets[1];
            }

            if (GameManager.instance.Base3Count > GameManager.instance.Base1Count && GameManager.instance.Base3Count > GameManager.instance.Base2Count)
            {
                target = targets[2];
            }
        }
        timer = ItervalofChanges;
    }

    void Update()
    {
        if ( tags.tags == PlayerTagss.Seeker)
        {
            if(GameManager.instance.timer <= 0)
            {
                if (playerClose)
                {
                    target = targets[3];
                }
                else if (GameManager.instance.Base1Count > GameManager.instance.Base2Count && GameManager.instance.Base1Count > GameManager.instance.Base3Count)
                {
                    target = targets[0];
                }
                else if (GameManager.instance.Base2Count > GameManager.instance.Base1Count && GameManager.instance.Base2Count > GameManager.instance.Base3Count)
                {
                    target = targets[1];
                }
                else if (GameManager.instance.Base3Count > GameManager.instance.Base1Count && GameManager.instance.Base3Count > GameManager.instance.Base2Count)
                {
                    target = targets[2];
                }

                if (canMove)
                {
                    ChaseTarget();
                }
            }
           
        }
        else
        {
            timer -= Time.deltaTime;
            int randomSpawnIndex = Random.Range(0,3);
            if (timer <= 0)
            {
                target = targets[randomSpawnIndex];
                if (canMove)
                {
                    ChaseTarget();
                }
                timer = 10;

            }
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerClose = true;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            otherTags = other.GetComponent<PlayerTag>();
           if (playerClose)
            {
                if (GameManager.instance.timer <= 0)
                {
                    if (tags.tags == PlayerTagss.Seeker)
                    {
                        timer = 2;
                        tags.tags = PlayerTagss.Hider;
                        otherTags.tags = PlayerTagss.Seeker;
                        GameManager.instance.timer = 10;
                    }
                }
               
               
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerClose = false;
        }
    }
    void ChaseTarget()
    {
        if (target != null && agent != null)
        {
            Debug.Log("Follow");
            Vector3 dodgeDestination = target.position;

            // Set destination to dodgeDestination
            agent.SetDestination(dodgeDestination);
        }
    }
}
