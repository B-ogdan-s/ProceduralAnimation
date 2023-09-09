using UnityEngine;

public class ProceduralAnimationLegs : MonoBehaviour
{
    [SerializeField, Min(0)] private float _stepDistans;
    [SerializeField, Min(0)] private float _stepHeight;
    [SerializeField, Min(0)] private float _stepSpeed;

    [SerializeField] private Transform[] _legsTransform;
    [SerializeField] private LegRayInfo _legsRayInfo;

    [SerializeField] private Vector3[] _legsLokalPosition;

    public LegRayInfo LegsRayInfo => _legsRayInfo;
    public Vector3[] LegsLokalPosition => _legsLokalPosition;


    private void Awake()
    {
        _legsLokalPosition = new Vector3[_legsTransform.Length];

        for(int i = 0; i < _legsTransform.Length; i++)
        {
            _legsLokalPosition[i] = _legsTransform[i].localPosition;
        }
    }

    private void Update()
    {
        for(int i = 0; i < _legsTransform.Length; i++)
        {
            _legsTransform[i].position = CheckGraund(i);
        }
    }

    private Vector3 CheckGraund(int indexLeg)
    {
        Vector3 newPos = Vector3.positiveInfinity;

        Vector3 rayPos = _legsLokalPosition[indexLeg] + transform.position;
        rayPos.y += _legsRayInfo.RayLength - _legsRayInfo.RayOffset;

        Ray ray = new Ray(rayPos, -transform.up);
        if(Physics.SphereCast(ray, _legsRayInfo.SphereCastRadius, out RaycastHit hit, _legsRayInfo.RayLength, _legsRayInfo.Mask))
        {
            newPos = hit.point;
        }
        return newPos;
    }
}

[System.Serializable]
public class LegRayInfo
{
    [SerializeField] private bool _showGizmos = true;
    [SerializeField] private LayerMask _mask;
    [SerializeField, Min(0)] private float _rayOffset;
    [SerializeField, Min(0)] private float _rayLength;
    [SerializeField, Min(0)] private float _sphereCastRadius;

    public bool ShowGizmos => _showGizmos;
    public LayerMask Mask => _mask;
    public float RayOffset => _rayOffset;
    public float RayLength => _rayLength;
    public float SphereCastRadius => _sphereCastRadius;
}
