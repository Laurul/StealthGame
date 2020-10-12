using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof (FovCOne))]
public class FovEditor : Editor
{
    private void OnSceneGUI()
    {
        FovCOne fov = (FovCOne) target;

        Handles.color = Color.blue;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);

        Vector3 viewAngleA = fov.VectorFromAngle(-fov.viewAngle / 2, false);
        Vector3 viewAngleB= fov.VectorFromAngle(fov.viewAngle/ 2, false);

        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewRadius);
    }
}
