using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseControls : MonoBehaviour {
    public NavMeshAgent thisAgent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

       
            if (Physics.Raycast(mouseRay,
                out hitInfo, 100))
            {
                MoveAI(hitInfo.point);
            }
            else
            {
                print("Nothing here");
            }
        }
	}

    void MoveAI(Vector3 targetPosition)
    {
        thisAgent.SetDestination(targetPosition);
    }
}
