using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad()]
public class WaypointEditor
{
    [DrawGizmo(GizmoType.NonSelected|GizmoType.Pickable|GizmoType.Selected)]
    public static void OnDrawSceneGizmo(Waypoint waypoint,GizmoType gizmoType)
    {
        if((gizmoType & GizmoType.Selected)!=0)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.red*0.5f;
        }
        Gizmos.DrawSphere(waypoint.transform.position, 0.1f);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(waypoint.transform.position + (waypoint.transform.right * waypoint.width / 2),
            waypoint.transform.position - (waypoint.transform.right * waypoint.width / 2));
        if(waypoint.previousWayPoint!=null)
        {
            Gizmos.color = Color.black;
            Vector3 offset = waypoint.transform.right * waypoint.width / 2;
            Vector3 offsetTo = waypoint.previousWayPoint.transform.right * waypoint.previousWayPoint.width / 2;
            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.previousWayPoint.transform.position + offsetTo);

        }
        if(waypoint.nextWayPoint!=null)
        {
            Gizmos.color = Color.black;
            Vector3 offset = waypoint.transform.right * -waypoint.width / 2;
            Vector3 offsetTo = waypoint.nextWayPoint.transform.right * -waypoint.nextWayPoint.width / 2;
            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.nextWayPoint.transform.position + offsetTo);
        }
    }
}
