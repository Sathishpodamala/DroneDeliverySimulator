using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    [SerializeField] CharacterNavigationController cnc;
    public Waypoint currentWaypoint;
    int direction;
    private void Awake()
    {
        cnc = GetComponent<CharacterNavigationController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        direction = Mathf.RoundToInt(Random.Range(0, 2));
        cnc.SetDestination(currentWaypoint.GetPosition());
    }

    // Update is called once per frame
    void Update()
    {
        if(cnc.reachedDestination)
        {
            if(direction == 0)
            {
                currentWaypoint = currentWaypoint.nextWayPoint;
            }
            else
            {
                currentWaypoint = currentWaypoint.previousWayPoint;
            }
            cnc.SetDestination(currentWaypoint.GetPosition());
        }
    }
}
