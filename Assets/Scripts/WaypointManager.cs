using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] waypoints;

    public GameObject[] getWayPoints()
    {
        return waypoints;
    }

    public GameObject getWayPoint(int counter)
    {
        Debug.Assert(counter >= 0 && counter < waypoints.Length);
        return waypoints[counter];
    }
}
