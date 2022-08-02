using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint previousWayPoint;
    public Waypoint nextWayPoint;
    [Range(0f,5f)]
    public float width = 2.8f;
    public Vector3 GetPosition()
    {
        Vector3 minbounds = transform.position + transform.right * width / 2;
        Vector3 maxbounds = transform.position - transform.right * width / 2;
        return Vector3.Lerp(minbounds, maxbounds, Random.Range(0, 1f));
    }
}
