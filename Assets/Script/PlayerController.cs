using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public PlayerTag tags;
    public PlayerTag enemyTag;
    public PlayerControls timerEnemy;
    void Start()
    {
        tags = GetComponent<PlayerTag>();
    }

    void Update()
    {
        // Check for user input (e.g., mouse click)
        if (Input.GetMouseButton(0))
        {
            if (tags.tags == PlayerTagss.Seeker)
            {
                if (GameManager.instance.timer <= 0)
                {
                    // Raycast from mouse position to determine target position on NavMesh
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        // Move player to the target position on the NavMesh
                        agent.SetDestination(hit.point);
                    }
                }
            }
            else
            {
                // Raycast from mouse position to determine target position on NavMesh
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // Move player to the target position on the NavMesh
                    agent.SetDestination(hit.point);
                }
            }
            
           
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyTag = other.GetComponent<PlayerTag>();
            
            if (GameManager.instance.timer <= 0)
            {
                if (tags.tags == PlayerTagss.Seeker)
                {
                    timerEnemy.timer = 2;
                    GameManager.instance.timer = 10;
                    enemyTag.tags = PlayerTagss.Seeker;
                    tags.tags = PlayerTagss.Hider;
                }
            }
        }
    }
}
