using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ProceduralAnimationLegs))]
public class ProceduralAnimationLegsScene : Editor
{
    private ProceduralAnimationLegs _target;
    private LegRayInfo _info;

    private void Awake()
    {
        _target = target as ProceduralAnimationLegs;
        _info = _target.LegsRayInfo;
    }

    private void OnSceneGUI()
    {
        if (!_info.ShowGizmos)
            return;


        for(int i = 0; i < _target.LegsLokalPosition.Length; i++)
        {
            DrawSphere(_target.LegsLokalPosition[i]);
        }
    }



    private void DrawSphere(Vector3 position)
    {
        position += _target.transform.position;
        position.y -= _info.RayOffset;
        Handles.color = Color.green;
        Handles.DrawWireDisc(position, Vector3.up, _info.SphereCastRadius);
        Handles.DrawWireDisc(position, Vector3.forward, _info.SphereCastRadius);
        Handles.DrawWireDisc(position, Vector3.right, _info.SphereCastRadius);
    }
}
