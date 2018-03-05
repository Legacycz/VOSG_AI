using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AIState
{
    PATROLLING,
    CHASING,
    ATTACKING
}

public class EnemyAI : MonoBehaviour {
    public Transform currentTarget;
    public NavMeshAgent thisAgent;
    public float speed = 1;
    public AIState currentState;

	// Use this for initialization
	void Start () {
        currentState = AIState.PATROLLING;
        thisAgent.destination = currentTarget.position;
	}
	
	// Update is called once per frame
	void Update () {
        switch(currentState)
        {
            case AIState.PATROLLING:
                {
                    UpdatePatrolling();
                    break;
                }
            case AIState.CHASING:
                {
                    UpdateChasing();
                    break;
                }
            case AIState.ATTACKING:
                {
                    UpdateAttacking();
                    break;
                }
        }










		if(currentTarget)
        {
            if (Vector3.Distance(transform.position,
                currentTarget.position) > 1.25f)
            {
                //print("moving");
                //transform.LookAt(currentTarget);
                //transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            else
            {
                print("select target");
                currentTarget = WaypointManager.Instance.GetRandomWaypoint();
                thisAgent.destination = currentTarget.position;
            }
        }
	}


    void UpdatePatrolling()
    {
        if(Vector3.Distance(transform.position,
            WaypointManager.Instance.player.position) < 10)
        {
            print("Changing state to CHASING");
            currentState = AIState.CHASING;
        }
    }

    void UpdateChasing()
    {
        thisAgent.destination = 
            WaypointManager.Instance.player.position;

        if (Vector3.Distance(transform.position,
            WaypointManager.Instance.player.position) < 3)
        {
            print("Changing state to ATTACKING");
            currentState = AIState.ATTACKING;
        }

        if (Vector3.Distance(transform.position,
            WaypointManager.Instance.player.position) > 15)
        {
            print("Changing state to PATROLLING");
            currentState = AIState.PATROLLING;
            thisAgent.destination = currentTarget.position;
        }
    }

    void UpdateAttacking()
    {
        if (Vector3.Distance(transform.position,
            WaypointManager.Instance.player.position) > 4)
        {
            print("Changing state to CHASING");
            currentState = AIState.CHASING;
        }
    }
}
