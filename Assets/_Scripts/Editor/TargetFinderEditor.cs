using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TargetFinder))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        TargetFinder tgtFdr = (TargetFinder)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(tgtFdr.transform.position, Vector3.up, Vector3.forward, 360, tgtFdr.viewRadius);        

        Handles.color = Color.red;
        foreach (Transform visableTarget in tgtFdr.visableTargets)
            if (visableTarget != null)
            {
                Handles.DrawLine(tgtFdr.transform.position, visableTarget.position);
            }
    }
}