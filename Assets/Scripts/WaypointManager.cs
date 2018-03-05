using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour {
    public static WaypointManager Instance { get; private set; }

    public Transform player;
    public List<Transform> waypoints = new List<Transform>();
    
	void Awake ()
    {
        Instance = this;
	}
	
	public Transform GetRandomWaypoint ()
    {
		return waypoints[Random.Range(0, waypoints.Count)];
	}
}
